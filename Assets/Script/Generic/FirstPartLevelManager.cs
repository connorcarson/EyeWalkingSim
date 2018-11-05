using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPartLevelManager : MonoBehaviour
{
    public float gameTimer;
    public EGameProcess gameProcess = EGameProcess.PREPARE;

    private bool leftEyeState;
    private bool rightEyeState;
    
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
        //StartCoroutine(PrepareCountDown(gameTimer));
        gameProcess = EGameProcess.FollowQuestPROCEED;
        //StartCoroutine(LevelCountDown(gameTimer));
    }

    void Update()
    {
        //这里写的有点不太好，不能够把所有的条件都整合在这个脚本里面进行check和控制，目前只有眼睛开闭经此控制，因为这是一个及时性的检测机制
        if (gameProcess == EGameProcess.EyeClosePROCEED)
        {
            EyeCloseStateCheck();
        }

}

    
    public GameObject leftEye;
    public GameObject rightEye;
    public AudioSource seaAudio;
    
    void EyeCloseStateCheck()
    {
                Debug.Log(gameProcess);
                leftEyeState = leftEye.GetComponent<EyeInteraction>().eyeClosed;
                rightEyeState = rightEye.GetComponent<EyeInteraction>().eyeClosed;
                if (leftEyeState && rightEyeState)
                {
                    gameProcess = EGameProcess.HallwayPROCEED;
                    //门开的方式
                }
    }

    IEnumerator LevelCountDown(float timeCountDown)
    {
        yield return new WaitForSeconds(timeCountDown);
        Debug.LogWarning("Level Over");
        gameProcess = EGameProcess.END;

        //TODO Do Something
    }

}
