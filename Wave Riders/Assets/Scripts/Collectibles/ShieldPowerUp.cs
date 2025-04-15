using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShieldPowerUp : MonoBehaviour,ICollectible
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    void Update()
    {
        if (this.CompareTag("Collectible"))
        {
            this.transform.Rotate(Vector3.up);
        }

    }

    public void Collect()
    {
        HUD.powerupNum++;
        AudioManager.instance.PlaySFX("ShieldPickUp");
        Destroy(this.gameObject);
    }
}
