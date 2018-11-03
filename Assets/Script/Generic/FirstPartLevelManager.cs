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
        gameProcess = EGameProcess.EyeClosePROCEED;
        //StartCoroutine(LevelCountDown(gameTimer));
    }

    void Update()
    {
        EyeCloseStateCheck();
        
    }

    
    public GameObject leftEye;
    public GameObject rightEye;
    public AudioSource seaAudio;
    
    void EyeCloseStateCheck()
    {
                Debug.Log(gameProcess);
                leftEyeState = leftEye.GetComponent<EyeInteraction>().eyeClosed;
                rightEyeState = rightEye.GetComponent<EyeInteraction>().eyeClosed;
                if (leftEyeState && rightEyeState && gameProcess == EGameProcess.EyeClosePROCEED)
                {
                    gameProcess = EGameProcess.EyeToBoat;
                    seaAudio.Play();
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
