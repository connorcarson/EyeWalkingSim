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
     			FollowQuest.Instance.TrueAnswer();
                 FollowQuest.Instance.FalseAnswer();
     		}
     		
     		
     	}
}
