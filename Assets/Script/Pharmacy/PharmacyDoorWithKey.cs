using UnityEngine;

public class PharmacyDoorWithKey : MonoBehaviour
{
    public GameObject Key;
    private Animator ani;
    public AudioClip DoorOpen;
    public AudioClip KeyUnfit;
    private AudioSource myAud;

    public void BeenClicked()
    {
        if (PickupController.Instance.pickupObj == Key)
        {
            ani.SetTrigger("Open");
            myAud.clip = DoorOpen;
            myAud.Play();
        }
        else if (PickupController.Instance.pickupObj != null)
        {
            myAud.clip = KeyUnfit;
            myAud.Play();
        }
    }
}