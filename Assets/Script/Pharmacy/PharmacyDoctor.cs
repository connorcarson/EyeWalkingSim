using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PharmacyDoctor : MonoBehaviour
{
	private AudioSource voice;

	private void Start()
	{
		voice = GetComponent<AudioSource>();
	}

	public void BeenClicked()
	{
		TextController.Instance.showText("Please, take the pillHs.", voice);
	}
}
