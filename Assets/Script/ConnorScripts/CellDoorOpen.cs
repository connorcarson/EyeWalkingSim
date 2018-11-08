using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellDoorOpen : MonoBehaviour
{

    private Animator ani;
    public AudioClip DoorOpen;
    private AudioSource myAud;
    
    private void OnTriggerEnter(Collider other)
    {
        ani.SetTrigger("Open");
        myAud.clip = DoorOpen;
        myAud.Play();
    }
}
