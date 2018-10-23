using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenaratedColorObject : MonoBehaviour
{
    public Material material;
    public Vector3 color;
    
    void Awake ()
    {
        material = this.GetComponent<Renderer>().material;

        //Random Color
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        color = new Vector3(r, g, b);
        material.SetColor("_Color", new Color(color.x, color.y, color.z));

        ColorizeLevelManager.Instance.OnColorGenerated();
    }
	
}
