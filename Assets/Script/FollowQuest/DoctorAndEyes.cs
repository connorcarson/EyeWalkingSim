using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoctorAndEyes : MonoBehaviour
{
	public bool commandStart;
	public Text theText;

	public AudioSource doctorVoice;
	public AudioClip doorKnock;
	public GameObject doctor;
	AudioSource myAud;
	// Use this for initialization
	void Start()
	{
		theText = GameObject.FindGameObjectWithTag("Text").GetComponent<Text>();
		doctorVoice = doctor.GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
		if (FirstPartLevelManager.Instance.gameProcess == EGameProcess.DoctorPuzzelPROCEED && commandStart==false)
		{
			//最开始的命令
			doctor.SetActive(true);
			GameObject.FindGameObjectWithTag("GameController").GetComponent<DoctorAndEyes>().commandStart = false;
			myAud = GetComponent<AudioSource>();
			myAud.clip = doorKnock;
			myAud.Play();
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
