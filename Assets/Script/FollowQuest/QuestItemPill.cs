using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItemPill : MonoBehaviour {

	public int caseNumber;
	public bool DoctorQuest;
	// Use this for initialization
	void Start () {
		//DoctorQuest=GameObject.FindGameObjectWithTag("Doctor").GetComponent<DoctorAndEyes>().commandStart;
	}
     	
	// Update is called once per frame
	void Update () {
		DoctorQuest=GameObject.FindGameObjectWithTag("GameController").GetComponent<DoctorAndEyes>().commandStart;
	}
     
	public void OnMouseEnter()
	{
		if (FollowQuest.Instance.followTheQuest && caseNumber==FollowQuest.Instance.orderCase)
		{
			//显示UI
			if (Input.GetKeyDown(0))
			{
				FollowQuest.Instance.TrueAnswer();
			}

			if (Input.GetKeyDown(1))
			{
				FollowQuest.Instance.FalseAnswer();
			}
		}

		if (DoctorQuest)
		{
			//显示UI
			if (Input.GetKeyDown(0))
			{
				FirstPartLevelManager.Instance.gameProcess = EGameProcess.FollowQuestPROCEED;
				GameObject.FindGameObjectWithTag("Doctor").SetActive(false);
				gameObject.SetActive(false);
				GameObject.FindGameObjectWithTag("GameController").GetComponent<DoctorAndEyes>().commandStart = false;
				AudioSource followOrderSound = GetComponent<AudioSource>();
				if (followOrderSound != null)
				{
					followOrderSound.Play();
				}
			}

			if (Input.GetKeyDown(1))
			{
				
			}
			//选择yes   FirstPartLevelManager.Instance.gameProcess = EGameProcess.FollowQuestPROCEED;
			//doctor回去
			//DoctorQuest = false;
			//不要用上面的代码了，免得出现错误
		}

	}
}
