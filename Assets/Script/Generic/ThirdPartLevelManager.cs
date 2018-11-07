using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPartLevelManager : MonoBehaviour {

	public EGameProcess gameProcess;
	
	private static ThirdPartLevelManager instance;
	public static ThirdPartLevelManager Instance
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

	void Start ()
	{
		//StartCoroutine(PrepareCountDown(gameTimer));
		gameProcess = EGameProcess.BoatPROCEED;
		//StartCoroutine(LevelCountDown(gameTimer));
	}
}
