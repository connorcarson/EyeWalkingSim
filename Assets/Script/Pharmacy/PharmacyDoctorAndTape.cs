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

        private void Start()
        {
            voice = GetComponent<AudioSource>();
            player=GameObject.FindWithTag("Player");
        }

        public void BeenClicked()
        {
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
        }

        private void Update()
        {
            distance = Vector3.Distance(this.transform.position, player.transform.position);
            playerFace = Vector3.Dot(player.transform.forward, player.transform.position - this.transform.position);
            if (FirstPartLevelManager.Instance.gameProcess == EGameProcess.DoctorPuzzelPROCEED)
            {
                if (distance > eyeTriggerDistance && playerFace > 0 && tapeUseNumber == tapeUse.Length)
                {
                    FirstPartLevelManager.Instance.gameProcess = EGameProcess.EyePuzzelPROCEED;
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<DoctorAndEyes>().commandStart =
                        false;
                    FirstPartLevelManager.Instance.rightEye.SetActive(true);
                    FirstPartLevelManager.Instance.leftEye.SetActive(false);
                }
            }
        }
    }
}