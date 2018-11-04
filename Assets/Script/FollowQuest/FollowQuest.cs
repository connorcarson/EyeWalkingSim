using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowQuest : MonoBehaviour {
	private int orderCase = 0;
	public TextAsset DialogueFile;
	public string[] DialogLine;

	public float waitSeconds = 3.0f;
	public bool followTheQuest = false;
	
	private static FollowQuest instance;
	public static FollowQuest Instance
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
	// Use this for initialization
	void Start()
	{
		if (DialogueFile != null)
		{
			DialogLine = (DialogueFile.text.Split('\n'));
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (FirstPartLevelManager.Instance.gameProcess == FollowQuest)
		{
			
			switch (orderCase)
			{
					
			}
		}
	}
	
	void TrueAnswer()
    {
    		switch (orderCase)
    		{
    				case 0:
    					
    				case 1:
    		}

		    WaitForFurtherTask(true);
	}

	void FalseAnswer()
	{
		
		WaitForFurtherTask(false);
	}

	IEnumerator WaitForFurtherTask(bool answer) //Next phase
	{
		yield return new WaitForSeconds(waitSeconds);
		if (answer)
		{
			if (orderCase != 4)
			{
				orderCase++;
			}
			else
			{
				orderCase = 0;
			}

			outcastOrder(orderCase);
		}
		else
		{
			outcastOrder(orderCase);
		}
	}

	void outcastOrder(int caseNumber)
	{
		switch (caseNumber)
		{
				//把东西弄乱TODO
		}
	}

}
