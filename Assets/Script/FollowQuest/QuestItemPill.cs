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
		//DoctorQuest=GameObject.FindGameObjectWithTag("GameController").GetComponent<DoctorAndEyes>().commandStart;
	}
     
	public void OnMouseEnter()
	{
		if (FirstPartLevelManager.Instance.gameProcess == EGameProcess.FollowQuestPROCEED && FollowQuest.Instance.followTheQuest && caseNumber==FollowQuest.Instance.orderCase)
		{
			Debug.Log("Findit");
			//显示UI
			if (Input.GetKeyDown(KeyCode.E))
			{
				FollowQuest.Instance.TrueAnswer();
			}

			if (Input.GetKeyDown(KeyCode.Q))
			{
				FollowQuest.Instance.FalseAnswer();
			}
		}else
		{

			//显示UI
		if (Input.GetKeyDown(KeyCode.E))
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

		if (Input.GetKeyDown(KeyCode.Q))
			{
				
			}
			//选择yes   FirstPartLevelManager.Instance.gameProcess = EGameProcess.FollowQuestPROCEED;
			//doctor回去
			//DoctorQuest = false;
			//不要用上面的代码了，免得出现错误
		}

	}
}
