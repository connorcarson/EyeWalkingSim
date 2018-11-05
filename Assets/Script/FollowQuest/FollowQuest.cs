using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowQuest : MonoBehaviour {
	public int orderCase = 0;
	public TextAsset DialogueFile;
	public string[] DialogLine;

	public float waitSeconds = 3.0f;
	public bool followTheQuest = false;
	private bool commandStart = false;
	private int pillMention = 0;
	
	//public Text theText;
	
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
		//theText = GameObject.FindWithTag("Text").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (FirstPartLevelManager.Instance.gameProcess == EGameProcess.FollowQuestPROCEED && commandStart == false)
		{
			//最开始的命令
			TextController.Instance.showText(DialogLine[orderCase]);
			commandStart = true;
		}
	}
	
	public void TrueAnswer()
    {
    		switch (orderCase)
    		{
    				case 0:
					    break;
    				case 1:
					    break;
				    case 4:
					    pillMention = 0;
    					break;
    		}

	    followTheQuest = false;
	    StartCoroutine(WaitForFurtherTaskTrue());
	}

	public void FalseAnswer()
	{
		followTheQuest = false;
		StartCoroutine(WaitForFurtherTaskFalse());
	}

	IEnumerator WaitForFurtherTaskTrue() //Next phase
	{
		if (commandStart == false)
		{
			yield break;
		}

		yield return new WaitForSeconds(waitSeconds);
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

	IEnumerator WaitForFurtherTaskFalse() //Next phase
	{
		if (commandStart == false)
		{
			yield break;
		}

		yield return new WaitForSeconds(waitSeconds);
		
		//pill exit
		if (orderCase == 4)
		{
			//pills
			pillMention++;
			if (pillMention == 2)
			{
				FirstPartLevelManager.Instance.gameProcess = EGameProcess.DoctorPuzzelPROCEED;
				RestartSetup();
				yield break;
			}
		}

		outcastOrder(orderCase);
	}
	
	void outcastOrder(int caseNumber)
	{
		switch (caseNumber)
		{
			case 1:
				//把东西弄乱TODO
			//声音
			//UI
				followTheQuest = true;
				break;
		}
	}

	void RestartSetup()
	{
		orderCase = 0;
		commandStart = false;
		followTheQuest = false;
		pillMention = 0;
	}
}
