using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PharmacyDoctor : MonoBehaviour
{
	private AudioSource voice;

	private void Start()
	{
		TextController.Instance.showText("Please, take the pillHs.", voice);
	}

	public void BeenClicked()
	{
		voice.Play();
	}
}
