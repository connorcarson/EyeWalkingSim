using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a script used to control the rotation of the eyelids
//Every time eyelids are clicked, they will close, and back to open after several seconds

//Remember to adjust the axis of the 3D model when changing the eyelid object
[RequireComponent(typeof(Animator))]
public class EyeInteraction : MonoBehaviour {

    public float maxOpenAngle = 40f;
    public float openLerpSpeed = 0.02f;
    public float closeAngleSpeed = 20f;
    public float angleDegLimit = 2f;

    private GameObject eyelidUp;
    private GameObject eyelidDown;
    public bool eyeClosed;
    private float waitForSeconds = 1f;
    private bool open = false;
    private bool close = false;
    
    void Start ()
    {
        eyelidUp = this.transform.Find("EyelidlUp").gameObject;
        eyelidDown = this.transform.Find("EyelidlDown").gameObject;
        //open = true;
    }

    void Update()
    {
        if (FirstPartLevelManager.Instance.gameProcess == EGameProcess.EyeClosePROCEED)
        {
            //This place can change if the range of the eyelids are changed
            if (open)
            {
                float angle;
                angle = Mathf.Lerp(eyelidDown.transform.rotation.eulerAngles.x, maxOpenAngle, openLerpSpeed);
                eyelidUp.transform.rotation = Quaternion.Euler(-angle, eyelidUp.transform.rotation.eulerAngles.y,
                    eyelidUp.transform.rotation.eulerAngles.z);
                eyelidDown.transform.rotation = Quaternion.Euler(angle, eyelidDown.transform.rotation.eulerAngles.y,
                    eyelidDown.transform.rotation.eulerAngles.z);

                if ((maxOpenAngle - angle) % 360 < angleDegLimit)
                {
                    open = false;
                }
            }
            else if (close)
            {
                float angle2;
                angle2 = Mathf.Lerp(eyelidDown.transform.rotation.eulerAngles.x, 0, closeAngleSpeed);
                eyelidUp.transform.rotation = Quaternion.Euler(-angle2, eyelidUp.transform.rotation.eulerAngles.y,
                    eyelidUp.transform.rotation.eulerAngles.z);
                eyelidDown.transform.rotation = Quaternion.Euler(angle2, eyelidDown.transform.rotation.eulerAngles.y,
                    eyelidDown.transform.rotation.eulerAngles.z);
                if (angle2 % 360 < angleDegLimit)
                {
                    close = false;
                    //waitForSeconds = waitForSeconds + 0.5f;
                    //StartCoroutine(EyeOpenCountdownNew(waitForSeconds));
                }
            }

            eyeClosed = eyelidDown.transform.rotation.eulerAngles.x < angleDegLimit ? true : false;
            Debug.Log(eyeClosed);
        }
          
    }

    //Call by player's input
    public void BeenClicked()
    {
        close = true;
        open = false;
        waitForSeconds = waitForSeconds + 0.5f;
         StartCoroutine(EyeOpenCountdownNew(waitForSeconds));
    }

    IEnumerator EyeOpenCountdownNew(float waitSeconds) //Next phase
    {
        Debug.Log(waitSeconds);
        yield return new WaitForSeconds(waitSeconds);
        open = true;
        close = false;
    }
}

[System.Serializable]
public struct CloseInfo
{
    public int clickCount;         //点击几次才能关闭
    public float nextOpenDelay;    //眼睛闭上后，下一次睁眼的延迟
}
