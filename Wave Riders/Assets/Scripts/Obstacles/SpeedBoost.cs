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
        if (other.CompareTag("Player") && PlayerController.Singleton.powerActive == false)
        {
            PlayerController playerController = PlayerController.Singleton;
            Debug.Log("Boosted");
            playerController.powerActive = true;
            playerCollider = other;
            Vector3 playerForward = PlayerController.Singleton.orientationCam.transform.forward;
            OriginalPlayerForwardVelocity = PlayerController.Singleton.rb.velocity;
            playerController.boostMultiplier = boostPercent;

            //deparent it from the level
            this.transform.parent = null;

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
        Destroy(this.gameObject);
    }
}