using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayDoorCloseTrigger : MonoBehaviour {

    public PlayerHallwayRun playerHallwayRun;
    public bool isOpening;

    private void Awake()
    {
        playerHallwayRun = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHallwayRun>();
    }
    
}
