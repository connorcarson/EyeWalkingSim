using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FireAnimator : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		transform.DOMoveY(-38, 10).SetEase(Ease.InBounce);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
