using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLift : MonoBehaviour {

	public float velocity = 2f;
	private bool doorStart = false;
	private float waitForSeconds;
	void Start () {
	}

	void Update () {
		if (FirstPartLevelManager.Instance.gameProcess == EGameProcess.EyeToBoat)
		{
			StartCoroutine(DoorWaitOpen(waitForSeconds));
		}

		if (doorStart)
		{
			this.gameObject.transform.Translate(0,velocity * Time.deltaTime,0, Space.Self );
		}
	}
	
	IEnumerator DoorWaitOpen(float waitSeconds) //Next phase
	{
		Debug.Log(waitSeconds);
		yield return new WaitForSeconds(waitSeconds);
		doorStart = true;
	}
}
 