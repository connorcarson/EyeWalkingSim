using UnityEngine;

namespace Script.Pharmacy
{
    public class PharmacyDoctorAndTape : MonoBehaviour
    {
        private AudioSource voice;
        public GameObject tape;
        public GameObject[] tapeUse;
        private int tapeUseNumber=0;
        private float distance;
        public float eyeTriggerDistance;
        private float playerFace;
        private GameObject player;
        public GameObject doctor;
        private AudioSource myAud;
        public AudioClip tapeSound;

        private void Start()
        {
            voice = doctor.GetComponent<AudioSource>();
            player=GameObject.FindWithTag("Player");
            myAud = GetComponent<AudioSource>();
        }

        /*public void BeenClicked()
        {
            Debug.Log("GlasswallBeenClicked");
            if (tapeUseNumber != tapeUse.Length)
            {
                if (PickupController.Instance.pickupObj == tape && tapeUseNumber!=tapeUse.Length)
                            {
                                tapeUse[tapeUseNumber].SetActive(true);
                                tapeUseNumber++;
                            }
                else
                {
                    TextController.Instance.showText("Please, take the pillHs.", voice);
                }
            }
        }*/

        private void Update()
        {
            distance = Vector3.Distance(this.transform.position, player.transform.position);
            playerFace = Vector3.Dot(player.transform.forward, player.transform.position - this.transform.position);
            
            if (FirstPartLevelManager.Instance.gameProcess == EGameProcess.DoctorPuzzelPROCEED)
            {
                if (RayCast.Instance.raycastFind && RayCast.Instance.hit.collider.gameObject == gameObject)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (tapeUseNumber != tapeUse.Length)
                        {
                            if (PickupController.Instance.pickupObj == tape && tapeUseNumber != tapeUse.Length)
                            {
                                tapeUse[tapeUseNumber].SetActive(true);
                                tapeUseNumber++;
                                myAud.clip=tapeSound;
                                myAud.Play();
                                if (tapeUseNumber == tapeUse.Length)
                                {
                                    tape.SetActive(false);
                                    PickupController.Instance.pickupObj = null;
                                }
                            }
                            else
                            {
                                TextController.Instance.showText("Please, take the pills.", voice);
                            }
                        }
                    }
                }

                
                if (distance > eyeTriggerDistance && playerFace > 0 && tapeUseNumber == tapeUse.Length)
                {
                    FirstPartLevelManager.Instance.gameProcess = EGameProcess.EyePuzzelPROCEED;
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<DoctorAndEyes>().commandStart =
                        false;
                    FirstPartLevelManager.Instance.rightEye.SetActive(true);
                    FirstPartLevelManager.Instance.leftEye.SetActive(true);
                }
            }
        }
    }
}