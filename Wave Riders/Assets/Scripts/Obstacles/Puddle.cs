using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour, IObstacle
{
    PlayerController playerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController = other.GetComponentInParent<PlayerController>();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collide();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.puddleMultiplier = 1f;
        }
    }

    public void Collide()
    {
        playerController.puddleMultiplier = 0.5f;

        //AudioManager.instance.PlaySFX("CarCrash");
    }
}
