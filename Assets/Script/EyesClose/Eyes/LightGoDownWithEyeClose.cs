using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGoDownWithEyeClose : MonoBehaviour
{
	private GameObject light;
	private GameObject eyelid;
	private float maxIntensity;

	private float maxOpenAngle;
	// Use this for initialization
	void Start ()
	{
		light = this.transform.Find("EyeLight").gameObject;
		eyelid = this.transform.Find("EyelidlDown").gameObject;
		maxIntensity = light.GetComponent<Light>().intensity;
		maxOpenAngle = this.GetComponent<EyeInteraction>().maxOpenAngle;
	}
	
	// Update is called once per frame
	void Update ()
	{
		light.GetComponent<Light>().intensity = (eyelid.transform.rotation.eulerAngles.x / maxOpenAngle) * maxIntensity;
	}
}
