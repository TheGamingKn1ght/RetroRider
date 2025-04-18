using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private int boostVal;
    private float boostPercent;
    private float BoostDuration = 3f;
    private Vector3 OriginalPlayerForwardVelocity;
    private Collider playerCollider;

    private void Start()
    {
        boostPercent =  1f + (boostVal / 1000f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponentInParent<PlayerController>().powerActive == false)
        {
            PlayerController playerController = other.GetComponentInParent<PlayerController>();
            Debug.Log("Boosted");
            playerController.powerActive = true;
            playerCollider = other;
            Vector3 playerForward = other.GetComponentInParent<PlayerController>().orientationCam.transform.forward;
            OriginalPlayerForwardVelocity = other.GetComponentInParent<Rigidbody>().velocity;
            playerController.boostMultiplier = boostPercent;

            AudioManager.instance.PlaySFX("SpeedBoost");
            
            StartCoroutine(BoostTimer(playerController));
        }
    }

    private IEnumerator BoostTimer(PlayerController playerController)
    {
        Debug.Log("Boost Timer Started");
        yield return new WaitForSeconds(BoostDuration);
        playerController.boostMultiplier = 1f;
        playerController.powerActive = false; 
        Debug.Log("Boost Ended");
    }
}