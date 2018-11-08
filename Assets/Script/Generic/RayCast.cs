using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour {

	private static RayCast instance;
	public static RayCast Instance
	{
		get
		{
			return instance;
		}
	}
	
	void Awake()
	{
		instance = this;
	}
	
	private Camera ca;
	private Ray ra;
	public RaycastHit hit;
	public bool raycastFind;
	
	void Start ()
	{
		ca = Camera.main;
	}

	void Update()
	{
		ra = ca.ScreenPointToRay(Input.mousePosition);
		raycastFind = Physics.Raycast(ra, out hit);
		//if(raycastFind){Debug.Log("findraycast");}
	}
}
