using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPartLevelManager : MonoBehaviour
{
    public float gameTimer;
    public EGameProcess gameProcess = EGameProcess.PREPARE;

    private static FirstPartLevelManager instance;
    public static FirstPartLevelManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
    }

    void Start ()
    {
        gameProcess = EGameProcess.EyeClosePROCEED;
        //StartCoroutine(LevelCountDown(gameTimer));
    }
	
    IEnumerator LevelCountDown(float timeCountDown)
    {
        yield return new WaitForSeconds(timeCountDown);
        Debug.LogWarning("Level Over");
        gameProcess = EGameProcess.END;

        //TODO Do Something
    }
}
