using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    public int caseNumber;

	
     	// Use this for initialization
     	void Start ()
	     {
	     }
     
     	void Update()
     	{
		     if (RayCast.Instance.raycastFind && RayCast.Instance.hit.collider.gameObject == gameObject)
		     {
			    
			     if (FollowQuest.Instance.followTheQuest && caseNumber == FollowQuest.Instance.orderCase)
			     { Debug.Log("findme");
				     //显示UI
				     if (Input.GetKeyDown(KeyCode.E))
				     {
					     FollowQuest.Instance.TrueAnswer();
				     }

				     if (Input.GetKeyDown(KeyCode.Q))
				     {
					     FollowQuest.Instance.FalseAnswer();
				     }
			     }
		     }
	     }
}
