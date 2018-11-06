using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayDoorAni : MonoBehaviour
{
	private PlayerHallwayRun playerHall;
	private Animator ani;

	public float sanLimit;
	private float sanRatio;
	// Use this for initialization
	void Start () {
		playerHall=GameObject.FindWithTag("Player").GetComponent<PlayerHallwayRun>();
		ani = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		sanRatio = playerHall.sanValue / playerHall.sanValueMaxium;
		if (sanRatio > sanLimit)
		{
			ani.SetTrigger("Open");
		}
		else
		{
			ani.SetTrigger("Close");
		}
	}
}
