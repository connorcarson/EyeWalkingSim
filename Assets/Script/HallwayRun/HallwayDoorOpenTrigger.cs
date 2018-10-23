using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayDoorOpenTrigger : MonoBehaviour
{   
    //This class is used to adjust the alpha of the door while adjust the use of the door's collider
    public Material _mat;
    public float _alpha = 0;
    private bool _isFadeIn = true;
    
    public GameObject player;
    public PlayerHallwayRun playerHallwayRun;
    public float openDoorTime = 0.1f;
    
    public GameObject doorTrigger;
    private bool doorTriggered;
    public GameObject doorSelf;
    
    void Start()
    {   //
        doorSelf = this.transform.Find("DoorSelf").gameObject;
        doorTrigger = this.transform.Find("DoorTrigger").gameObject;
        
        //
        _mat = doorSelf.GetComponent<Renderer>().material;
        _mat.color = new Color(1, 1, 1, _alpha);
        
        player = GameObject.FindGameObjectWithTag("Player");
        playerHallwayRun = player.GetComponent<PlayerHallwayRun>();
    }

    void Update()
    {
        //Debug.Log(playerHallwayRun.sanValue / playerHallwayRun.sanValueMaxium);
        _alpha = playerHallwayRun.sanValue / playerHallwayRun.sanValueMaxium;
        //_alpha += (_isFadeIn ? 1 : -1) * Time.deltaTime / 2;
        _mat.color = new Color(1, 1, 1, _alpha);
        //if (_alpha > 1) _isFadeIn = false;
        //if (_alpha < 0) _isFadeIn = true;
        doorTriggered = doorTrigger.GetComponent<ExitDoorTrigger>().doorTriggered;
        if (this.GetComponent<HallwayDoorOpenTrigger>()._alpha <openDoorTime ||doorTriggered)
        {
            doorSelf.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            doorSelf.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
