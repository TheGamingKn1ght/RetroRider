using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour, IObstacle
{
    PlayerController playerController;


    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
             playerController = other.GetComponentInParent<PlayerController>();

             Collide();
            
        }
    }

    public void Collide()
    {
        if (!playerController.boostActive)
        {
            HealthSystem.Singleton.applyDamage(25);
        }
        AudioManager.instance.PlaySFX("Laser");
    }
}
