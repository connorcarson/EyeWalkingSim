﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class FollowQuest : MonoBehaviour {
	public int orderCase = 0;
	public TextAsset DialogueFile;
	public string[] DialogLine;
	public GameObject[] MassObj;
	public GameObject[] TidyObj;
	public AudioClip mumble;
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
			if (mumble != null)
			{
				GetComponent<AudioSource>().clip = mumble;
				TextController.Instance.showText(DialogLine[orderCase], GetComponent<AudioSource>());
			}
			else
			{
				TextController.Instance.showText(DialogLine[orderCase], null);
			}
			
			GeneralMove(orderCase);
			commandStart = true;
		}
	}
	
	public void TrueAnswer()
    {
	    GeneralMove(orderCase);
	    if (orderCase == MassObj.Length-1)
	    {
		     pillMention = 0;
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
		if (orderCase != MassObj.Length-1)
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
		if (orderCase == MassObj.Length-1)
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

		if (mumble != null)
		{
			GetComponent<AudioSource>().clip = mumble;
			TextController.Instance.showText(DialogLine[orderCase], GetComponent<AudioSource>());
		}
		else
		{
			TextController.Instance.showText(DialogLine[orderCase], null);
		}
		followTheQuest = true;
	}

	void RestartSetup()
	{
		orderCase = 0;
		commandStart = false;
		followTheQuest = false;
		pillMention = 0;
	}

	void GeneralMove(int ordercase)
	{
		if(MassObj[ordercase]!=null){MassObj[ordercase].SetActive(!MassObj[ordercase].activeSelf);}
		if(TidyObj[ordercase]!=null){TidyObj[ordercase].SetActive(!TidyObj[ordercase].activeSelf);}
	}
	
}
