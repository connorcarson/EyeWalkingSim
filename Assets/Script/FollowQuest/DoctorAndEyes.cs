using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoctorAndEyes : MonoBehaviour
{
	public bool commandStart;
	public Text theText;

	private AudioSource doctorVoice;
	private AudioSource doorKnock;
	// Use this for initialization
	void Start()
	{
		theText = GameObject.FindGameObjectWithTag("Text").GetComponent<Text>();
		doctorVoice = GameObject.FindGameObjectWithTag("Doctor").GetComponent<AudioSource>();
		doorKnock = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
		if (FirstPartLevelManager.Instance.gameProcess == EGameProcess.DoctorPuzzelPROCEED && commandStart==false)
		{
			//最开始的命令
			GameObject.FindGameObjectWithTag("Doctor").SetActive(true);
			GameObject.FindGameObjectWithTag("Doctor").GetComponent<DoctorAndEyes>().commandStart = false;
			doorKnock.Play();
			TextController.Instance.showText("Please, take the pillHs.", doctorVoice);
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
	
}
