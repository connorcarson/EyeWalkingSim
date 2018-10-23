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

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHallwayRun = player.GetComponent<PlayerHallwayRun>();

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
        }
        else
        {
            isPlayerBackToSelf = false;
        }
    }

    void RefreshBehaviour()
    {
        CheckPlayerInRange();
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
}
