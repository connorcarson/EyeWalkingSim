using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorizeObject : MonoBehaviour
{
    public Material material;
    public Vector3 color;

    private void Awake()
    {
        material = this.GetComponent<Renderer>().material;
    }

    public void BeenClicked()
    {
        Debug.Log("BeenClicked");
        material.SetColor("_Color", new Color(color.x, color.y, color.z)); 
    }

    //https://docs.unity3d.com/Manual/MaterialsAccessingViaScript.html
}
