using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoctorAndEyes : MonoBehaviour
{
	public bool commandStart;
	public Text theText;
	// Use this for initialization
	void Start()
	{
		theText = GameObject.FindGameObjectWithTag("Text").GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {
		if (FirstPartLevelManager.Instance.gameProcess == EGameProcess.DoctorPuzzelPROCEED && commandStart==false)
		{
			//最开始的命令
			commandStart = true;
			//医生出现
			//窗户打开
			//配乐
		}

		if (commandStart)
		{
			//检查条件达成
			//commandStart = false;
			//FirstPartLevelManager.Instance.gameProcess == EGameProcess.EyeClosePROCEED;
		}
	}

	public void BeenClicked()
	{
		if (commandStart)
		{
			//voice:please, take the pill
			//theText.text= new string("Please, take the pill.");
			//theText.GetComponent<Text>().enabled = true;
			
		}
	}
	
}
