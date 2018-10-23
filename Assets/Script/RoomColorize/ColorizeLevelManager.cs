using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorizeLevelManager : MonoBehaviour
{
    public int wallFinshed = 0;
    public int wallCount;
    public bool isWallColorizedFinished;

    public int newColorGenerateNum = 0;
    public int newColorGenerateLimit = 20;
    public GameObject generateColorObjectPrefab;
    public bool isNewColorGenerateFinished;

    public static ColorizeLevelManager Instance
    {
        get { return instance; }
    }
    private static ColorizeLevelManager instance;

    private void Awake()
    {
        instance = this;
        wallCount = this.transform.childCount;
    }

    public void OnWallColorized()
    {
        wallFinshed++;
        if (wallFinshed >= wallCount)
        {
            isWallColorizedFinished = true;
        }
    }

    public void OnColorGenerated()
    {
        newColorGenerateNum++;
        if (newColorGenerateNum >= newColorGenerateLimit)
        {
            isNewColorGenerateFinished = true;
            Debug.Log("Generate Color Level Finished !");
            GenerateColorLevelFinished();
        }
    }

    void GenerateColorLevelFinished()
    {
        //TODO
    }
}
