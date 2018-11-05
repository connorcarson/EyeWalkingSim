using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorizeObject : MonoBehaviour
{
    public Material material;
    public Vector3 color;
    public bool isColorize;
    public ColorizeCubeWall colorizeCubeWall;

    private void Awake()
    {
        material = this.GetComponent<Renderer>().material;
        colorizeCubeWall = this.transform.parent.GetComponent<ColorizeCubeWall>();

        //Random Color
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        color = new Vector3(r, g, b); 
    }

    public void BeenClicked(GameObject target, RaycastHit hit)
    {
        Debug.Log("Color!");
        if (!isColorize)
        {
            material.SetColor("_Color", new Color(color.x, color.y, color.z));
            isColorize = true;
            colorizeCubeWall.OnCubeColorized();
        }
        else if(ColorizeLevelManager.Instance.isWallColorizedFinished && !ColorizeLevelManager.Instance.isNewColorGenerateFinished)
        {
            Vector3 hitPoint = hit.point;
            GameObject temp = GameObject.Instantiate(ColorizeLevelManager.Instance.generateColorObjectPrefab, hitPoint, target.transform.rotation, target.transform);
            float scaleVal = Random.Range(1, 3);
            float thickVal = ColorizeLevelManager.Instance.newColorGenerateNum * 0.02f + 0.2f;
            temp.transform.localScale = new Vector3(scaleVal, scaleVal, thickVal);
        }
    }

    //https://docs.unity3d.com/Manual/MaterialsAccessingViaScript.html
}
