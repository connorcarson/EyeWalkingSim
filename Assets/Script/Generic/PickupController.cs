using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public Camera ca;
    private Ray ra;
    private RaycastHit hit;
    private int flag = 0;
    private Vector3 pickupPos;

    // Use this for initialization  
    void Start()
    {
    }

    // Update is called once per frame  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ra = ca.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ra, out hit) && hit.collider.gameObject.CompareTag("canBePickup"))
            {
                if (flag == 0)
                {
                    flag = 1;
                    Debug.Log("Pickup!");
                }
                else
                {
                    flag = 0;
                }
            }
        }

        if (flag == 1)
        {
            if (hit.collider.gameObject.tag == "canBePickup")
            {
                //hit.collider.gameObject.transform.position = ca.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                    //Input.mousePosition.y, hit.collider.gameObject.transform.position.z));
                hit.collider.gameObject.transform.position = ca.ScreenToWorldPoint(GetComponentInChildren<Transform>().position);
            }
        }

    }
}
