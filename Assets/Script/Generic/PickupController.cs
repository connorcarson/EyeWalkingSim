using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public Camera ca;
    private Ray ra;
    public RaycastHit hit;
    public int flag = 0;
    private Vector3 pickupPos;
    private Quaternion pickupRot;
    public GameObject pickupObj;
    public Material outlineMat;

    private static PickupController instance;
    public static PickupController Instance
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
    
    // Update is called once per frame  
    void Update()
    {
        ra = ca.ScreenPointToRay(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.E))
        {
            //ra = ca.ScreenPointToRay(Input.mousePosition);
                if (pickupObj==null)
                {
                    if (Physics.Raycast(ra, out hit) && hit.collider.gameObject.CompareTag("canBePickup"))
                    {
                        pickupObj = hit.collider.gameObject;
                        Debug.Log("Pickup!");
                        if (pickupObj.GetComponent<Collider>() != null)
                        {
                            pickupObj.GetComponent<Collider>().enabled = false;
                        }
                    }
                }
                else
                {
                    Vector3 dropPos = transform.Find("DropPosition").position;
                    pickupObj.transform.position = dropPos;
                    if(pickupObj.GetComponent<Collider>()!=null)
                    {
                        pickupObj.GetComponent<Collider>().enabled = true;
                    }
                    pickupObj=null;
                }
        }

        if (pickupObj!=null)
        {
                //hit.collider.gameObject.transform.position = ca.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                    //Input.mousePosition.y, hit.collider.gameObject.transform.position.z));
                pickupPos = transform.Find("PickupPosition").position;
                pickupRot = transform.Find("PickupPosition").rotation;
                pickupObj.transform.position = pickupPos;
                pickupObj.transform.rotation = pickupRot;
        }
        
    }
}
