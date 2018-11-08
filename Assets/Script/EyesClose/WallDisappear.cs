using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDisappear : MonoBehaviour
{
	private float waitTime=5.0f;
	public GameObject[] wallLayer;
	public bool WallDisappearShift;
	private int layerNum = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!WallDisappearShift && FirstPartLevelManager.Instance.gameProcess==EGameProcess.HallwayPROCEED)
		{
			WallDis();
			WallDisappearShift = true;
		}
	}

	void WallDis()
	{
		StartCoroutine(waitAndDisappear(waitTime));
	}
	
	IEnumerator waitAndDisappear(float waitSeconds) //Next phase
	{
		yield return new WaitForSeconds(waitSeconds);
		wallLayer[layerNum].SetActive(false);
		layerNum++;
		if (layerNum != wallLayer.Length)
		{
			StartCoroutine(waitAndDisappear(waitTime));
		}
	}
}
