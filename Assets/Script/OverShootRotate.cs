using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 指定一个transform.position
 * 先进行 A 次随机偏移，指向目标+-某个角度范围内的一个点
 * 每次从当前角度到完成偏移需要 B 秒，偏移到目标点之后等待 C 秒
 * 最后会对准transform.position的位置
 * */

public class OverShootRotate : MonoBehaviour {

    public GameObject targetObj;
    public int overshootRotateCount;
    public int currentRotateCount;
    public float rotateDuration;
    public float rotateInterval;
    public float minRotateOffsetAngle;
    public float maxRotateOffsetAngle;
    
    private void Start()
    {
        Invoke("Rotate", 5f);

    }
    
    public void Rotate()
    {
        StopAllCoroutines();
        currentRotateCount = overshootRotateCount;
        Debug.Log("OffsetRotateStart");
        StartCoroutine("OffsetRotate", targetObj.transform.position);
    }

    IEnumerator FinalRotate()
    {
        //All OverShoot Rotate is Finshed, Rotate to target
        Debug.Log("FinalRotate Start");
        Vector3 startEuler = this.transform.rotation.eulerAngles;
        Vector3 targetEuler = GetLookAtTargetEulerAngle(targetObj.transform.position);
        rotateInfo info = new rotateInfo(rotateDuration, startEuler, targetEuler);
        yield return (StartCoroutine("RotateToTarget", info));
        Debug.Log("FinalRotate Over");
    }

    IEnumerator OffsetRotate(Vector3 targetPos)
    {
        while (currentRotateCount > 0)
        {
            this.currentRotateCount--;
            
            //Get Rotate Target
            Vector3 startEuler = this.transform.rotation.eulerAngles;
            Vector3 targetEuler = GetLookAtTargetEulerAngleOverShoot(targetPos);

            //Rotate Start
            rotateInfo info = new rotateInfo(rotateDuration, startEuler, targetEuler);
            yield return (StartCoroutine("RotateToTarget", info));
            
            //Rotate Finished ... Start Wait
            yield return new WaitForSeconds(rotateInterval);
        }
        Debug.Log("OffsetRotate Loop Over");
        StartCoroutine("FinalRotate");
    }

    IEnumerator RotateToTarget(rotateInfo info)
    {
        float timePassed = 0;
        while (timePassed < info.timeCoundDown)
        {
            timePassed += Time.deltaTime;
            float ratio = timePassed / info.timeCoundDown;
            float x = Mathf.LerpAngle(info.startEulerAngle.x, info.targetEulerAngle.x, ratio);
            float y = Mathf.LerpAngle(info.startEulerAngle.y, info.targetEulerAngle.y, ratio);
            float z = Mathf.LerpAngle(info.startEulerAngle.z, info.targetEulerAngle.z, ratio);
            this.transform.rotation = Quaternion.Euler(x, y, z);
            yield return new WaitForEndOfFrame();
        }
        this.transform.rotation = Quaternion.Euler(info.targetEulerAngle.x, info.targetEulerAngle.y, info.targetEulerAngle.z);
        Debug.Log("RotateToTarget Finished");
    }

    Vector3 GetLookAtTargetEulerAngle(Vector3 targetPos)
    {
        Quaternion targetQuaternion = Quaternion.LookRotation(targetPos);
        float xAngle = targetQuaternion.eulerAngles.x;
        float yAngle = targetQuaternion.eulerAngles.y;
        float zAngle = targetQuaternion.eulerAngles.z;
        return new Vector3(xAngle, yAngle, zAngle);
    }

    Vector3 GetLookAtTargetEulerAngleOverShoot(Vector3 targetPos)
    {
        Quaternion targetQuaternion = Quaternion.LookRotation(targetPos, this.transform.up);

        bool xpositive = (UnityEngine.Random.Range(0, 2) == 0);
        bool ypositive = (UnityEngine.Random.Range(0, 2) == 0);
        float xAngleOffset = UnityEngine.Random.Range(minRotateOffsetAngle,maxRotateOffsetAngle);
        float yAngleOffset = UnityEngine.Random.Range(minRotateOffsetAngle,maxRotateOffsetAngle);
        float xAngle = xpositive ? targetQuaternion.eulerAngles.x + xAngleOffset : targetQuaternion.eulerAngles.x - xAngleOffset;
        float yAngle = ypositive ? targetQuaternion.eulerAngles.y + yAngleOffset : targetQuaternion.eulerAngles.y - yAngleOffset;
        Debug.Log("x" + xAngle);
        Debug.Log("y" + yAngle);
        return new Vector3(xAngle, yAngle, targetQuaternion.eulerAngles.z);
    }
}

public struct rotateInfo
{
    public float timeCoundDown;
    public Vector3 startEulerAngle;
    public Vector3 targetEulerAngle;

    public rotateInfo(float timeCoundDown, Vector3 startEulerAngle, Vector3 targetEulerAngle)
    {
        this.timeCoundDown = timeCoundDown;
        this.startEulerAngle = startEulerAngle;
        this.targetEulerAngle = targetEulerAngle;
    }
}
