using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChasingLevelController : MonoBehaviour {

    public bool isProceed = false;
    public bool isFinished = false;
    public GameObject player;
    public GameObject chaseLight;

    public Transform playerStartPoint;
    public Transform playerEndPoint;
    public Transform lightStartPoint;
    public Transform lightEndPoint;

    float startEndDistance;

    private void Start()
    {
        Initialize();
    }

    void Update ()
    {
        if (isProceed && !isFinished)
        {
            /*
            float ratio = Mathf.Clamp01(Vector3.Distance(player.transform.position, playerStartPoint.position) / startEndDistance);
            chaseLight.transform.position = lightEndPoint.position * ratio + lightStartPoint.position * (1 - ratio);

            if (ratio > 0.99f)
            {
                isFinished = true;
                GameOver();
            }*/
            LightMoving();
        }
	}

    void Initialize()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        chaseLight = GameObject.FindGameObjectWithTag("ChaseLight");
        startEndDistance = Vector3.Distance(playerStartPoint.position, playerEndPoint.position);
        isProceed = true;
    }

    void LightMoving()
    {
        
    }

    void GameOver()
    {
        Debug.Log("GameOver");
        //TODO
    }
}
