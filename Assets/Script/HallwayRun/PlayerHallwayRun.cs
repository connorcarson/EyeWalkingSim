using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHallwayRun : MonoBehaviour
{
    public float sanValue;
    public float sanOpenDoorLimit = 10.0f;
    public float sanValueMaxium = 100.0f;
    public float sanValueAddSpeed = 20.0f;
    public float sanValueReduceSpeed = 10.0f;
    public List<HallwayEnemy> enemies = new List<HallwayEnemy>();
    public AudioSource footstepAudio;
    public float waitForSanDown = 5.0f;
    public bool isWaiting = false;

    void Start()
    {
        footstepAudio.Play();
    }

    void Update ()
    {
        if (enemies.Count > 0)
        {
            addSanValue();
            //check if need to play footstep audio
            foreach (HallwayEnemy enemy in enemies)
            {
                if (enemy.isPlayerBackToSelf)
                {
                    UpdateFootstepAudio();
                    return;
                }
            }
            MuteFootstepAudio();
        }
        else
        {
            if (isWaiting)
            {
                return;
            }

            if (sanValue/sanValueMaxium == 1.0f && isWaiting == false)
            {
                isWaiting = true;
                StartCoroutine(CountDownBeforeRedueceSan(waitForSanDown));
            }
            else
            {
                reduceSanValue();
                MuteFootstepAudio();
            }
        }
    }

    void addSanValue()
    {
        sanValue += sanValueAddSpeed * Time.deltaTime;
        sanValue = Mathf.Clamp(sanValue, 0, sanValueMaxium);
    }

    void reduceSanValue()
    {
        sanValue -= sanValueReduceSpeed * Time.deltaTime;
        sanValue = Mathf.Clamp(sanValue, 0, sanValue);
    }
 
    void UpdateFootstepAudio()
    {
        footstepAudio.volume = sanValue / sanValueMaxium;
    }

    void MuteFootstepAudio()
    {
        footstepAudio.volume = 0;
    }
    
    IEnumerator CountDownBeforeRedueceSan(float waitSeconds) //Next phase
    {
        yield return new WaitForSeconds(waitSeconds);
        reduceSanValue();
        isWaiting = false;
    }
} 
