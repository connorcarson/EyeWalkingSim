using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItemPill : MonoBehaviour {

	public int caseNumber;
	public bool DoctorQuest;
	// Use this for initialization
	void Start () {
		DoctorQuest=GameObject.FindGameObjectWithTag("Doctor").GetComponent<DoctorAndEyes>().commandStart;
	}
     	
	// Update is called once per frame
	void Update () {
     
	}
     
	public void OnMouseEnter()
	{
		if (FollowQuest.Instance.followTheQuest && caseNumber==FollowQuest.Instance.orderCase)
		{
			FollowQuest.Instance.TrueAnswer();
			FollowQuest.Instance.FalseAnswer();
		}

		if (DoctorQuest)
		{
			//选择yes   FirstPartLevelManager.Instance.gameProcess = EGameProcess.FollowQuestPROCEED;
			//doctor回去
			//DoctorQuest = false;
			//不要用上面的代码了，免得出现错误
		}

	}
}
