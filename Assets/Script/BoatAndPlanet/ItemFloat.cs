using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFloat : MonoBehaviour {

	private float radianX = 0; // 振幅
	private float radianY = 0;
	float radianZ = 0;
	public float perRadianX = 0.03f; // 每次变化的弧度
	public float perRadianY = 0.03f;
	public float perRadianZ = 0.03f;
	public float radiusX = 0.8f;
	public float radiusY = 0.8f;
	public float radiusZ = 0.8f;// 半径
	Vector3 oldPos; // 开始时候的坐标
	// Use this for initialization
	void Start () {
		oldPos = transform.position; // 将最初的位置保存到oldPos
	}
	
	// Update is called once per frame
	void Update () {
		radianX += perRadianX; // 弧度每次加0.03
		radianY += perRadianY;
		radianZ += perRadianZ;
		float dx = Mathf.Cos(radianX) * radiusX;
		float dy = Mathf.Cos(radianY) * radiusY; // dy定义的是针对y轴的变量，也可以使用sin，找到一个适合的值就可以
		float dz = Mathf.Cos(radianZ) * radiusZ;
		transform.position = oldPos + new Vector3 (dx, dy, dz);
		oldPos = transform.position;
	}
}
