﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour 
{
    public float h;
    public float v;

    private static BoatMove instance;
    public static BoatMove Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake ()
    {
        instance = this;
    }
	
	void Update ()
    {
        if (PlanetBoatLevelManager.Instance.gameProcess == EGameProcess.PROCEED)
        {
            h = Input.GetAxis("Horizontal") * Time.deltaTime;
            v = Input.GetAxis("Vertical") * Time.deltaTime;
            PlanetRotate.Instance.RotatePlanet(h, v);
        }
    }
}
