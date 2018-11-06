using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBeenPickedup : MonoBehaviour
{
	private Material myMat;
	// Use this for initialization
	void Start ()
	{
		myMat = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		if (PickupController.Instance.hit.collider.gameObject!=null && PickupController.Instance.hit.collider.gameObject== gameObject)
		{
			GetComponent<Renderer>().material = PickupController.Instance.outlineMat;
		}
		else
		{
			GetComponent<Renderer>().material = myMat;
		}

		if (PickupController.Instance.pickupObj == gameObject)
		{
			GetComponent<Renderer>().material = myMat;
		}
	}
}
