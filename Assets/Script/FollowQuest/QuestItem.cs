using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
     	public int caseNumber;
     	// Use this for initialization
     	void Start () {
     	}
     	
     	// Update is called once per frame
     	void Update () {
     
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
     	}
}
