using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorizeCubeWall : MonoBehaviour
{
    public int cubeColorizedCount = 0;
    public int childCount;

    private void Awake()
    {
        childCount = this.transform.childCount;
    }
    
    public void OnCubeColorized()
    {
        cubeColorizedCount++;
        if (cubeColorizedCount >= childCount)
        {
            ColorizeLevelManager.Instance.OnWallColorized();
            Destroy(this);
        }
    }
}
