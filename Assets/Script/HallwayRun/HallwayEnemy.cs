using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayEnemy : MonoBehaviour {
    
    public bool isFindPlayer;
    public bool isPlayerBackToSelf;
    public GameObject player;
    public PlayerHallwayRun playerHallwayRun;

    public float detectRatio;
    public float detectAngle;
    public float distance;
    public float angleBetween;

    private Ray rayForWall;
    private bool hitWall=false;

    public AudioSource footstepAudio;
    public float audioVolumeChangeSpeed = 0.05f;
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHallwayRun = player.GetComponent<PlayerHallwayRun>();
        footstepAudio.Play();
        footstepAudio.volume = 0f;
    }
	
	void Update ()
    {
        distance = Vector3.Distance(this.transform.position, player.transform.position);
        RaycastHit hitInfo;
        rayForWall = new Ray(this.transform.position, player.transform.position - this.transform.position);
        if (Physics.Raycast(rayForWall, out hitInfo))
        {
            string tag = hitInfo.transform.gameObject.tag;
            if (tag == "HallwayWalls")
            {
                hitWall = true;
            }else{
                hitWall = false;
            }
        }else{
            hitWall = false;
        }

        if (isFindPlayer)
        {
            LookAtPlayer();
        }
        else
        {
            RefreshBehaviour();
        }
	}

    void LookAtPlayer()
    {

        /* Not Used
         * float current = this.transform.rotation.eulerAngles.y;
         * Vector3 targetVector = (player.transform.position - this.transform.position).normalized;
         * float target = Mathf.Acos(targetVector.x/targetVector.z) * Mathf.Rad2Deg;
         * Debug.Log(target);
         * float now = Mathf.LerpAngle(current, target, turnSpeed * Time.deltaTime);
         * this.transform.rotation = Quaternion.Euler(0f, now, 0f);
         */

        this.transform.LookAt(new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z));
        CheckPlayerOutRange();

        //if player back to the enemy, then add San value
        if (Vector3.Dot(player.transform.forward, player.transform.position - this.transform.position) > 0)
        {
            isPlayerBackToSelf = true;
            UpdateFootstepAudio();
        }
        else
        {
            isPlayerBackToSelf = false;
            MuteFootstepAudio();
        }
    }

    void RefreshBehaviour()
    {
        CheckPlayerInRange();
        UpdateFootstepAudioDown();
        //Add new behaviour if need..
        
    }

    void CheckPlayerInRange()
    {
        if (distance <= detectRatio && hitWall==false)
        {
            float dotResult = Vector3.Dot(this.transform.forward.normalized, (player.transform.position - this.transform.position).normalized);
            angleBetween = Mathf.Acos(dotResult) * Mathf.Rad2Deg;
            if (angleBetween <= detectAngle)
            {
                isFindPlayer = true;
                playerHallwayRun.enemies.Add(this);
            }
            
        }
    }

    void CheckPlayerOutRange()
    {
        
        if (distance > detectRatio || hitWall)
        {
            isFindPlayer = false;
            isPlayerBackToSelf = false;
            playerHallwayRun.enemies.Remove(this);
        }
    }
    
    void UpdateFootstepAudio()
    {
        footstepAudio.volume = Mathf.Max(footstepAudio.volume +audioVolumeChangeSpeed, 1f);
    }

    void MuteFootstepAudio()
    {
        footstepAudio.volume = 0;
    }
    
    void UpdateFootstepAudioDown()
    {
        footstepAudio.volume = Mathf.Min(footstepAudio.volume -audioVolumeChangeSpeed, 0f);
    }
}
