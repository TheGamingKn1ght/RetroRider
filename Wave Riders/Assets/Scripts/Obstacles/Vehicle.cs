using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour, IObstacle
{
    private Vector3 playerForward;
    PlayerController playerController;


    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController = other.GetComponentInParent<PlayerController>();
            playerForward = other.GetComponentInParent<PlayerController>().orientationCam.transform.forward;

                Collide();
            
        }
    }

    public void Collide()
    {
        if (!playerController.boostActive)
        {
            HealthSystem.Singleton.applyDamage(15);
        }
        AudioManager.instance.PlaySFX("CarCrash");
    }
}
