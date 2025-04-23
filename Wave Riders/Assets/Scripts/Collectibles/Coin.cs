using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectible
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
        
        AudioManager.instance.PlaySFX("CoinPickUp");
        Destroy(this.gameObject);
    }
}
