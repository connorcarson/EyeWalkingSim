using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
	public float waitSeconds = 5.0f;

	
	public bool startCounting;
	private Coroutine lastCoroutine;
	
	private static TextController instance;
	public static TextController Instance
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
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (startCounting)
		{
			if (lastCoroutine != null)
			{
				StopCoroutine(lastCoroutine);
			}
			lastCoroutine=StartCoroutine(WaitForSecond(waitSeconds));
			startCounting = false;
		}
	}
	
	IEnumerator WaitForSecond(float waitSeconds) //Next phase
	{
		yield return new WaitForSeconds(waitSeconds);
		GetComponent<Text>().enabled = false;
	}

	public void showText(string dialog, AudioSource audio)
	{
		GetComponentInParent<Text>().text = dialog;
		GetComponentInParent<Text>().enabled = true;
		if (audio != null)
		{
			audio.Play();
		}
		startCounting = true;
	}
}
