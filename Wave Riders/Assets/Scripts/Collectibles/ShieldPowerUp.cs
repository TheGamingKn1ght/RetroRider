using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShieldPowerUp : MonoBehaviour,ICollectible
{
    [SerializeField] private TMP_Text powerUpText;

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
        //JumpBar.Singleton.AddPower(25);
        AudioManager.instance.PlaySFX("JumpPickUp");
        Destroy(this.gameObject);
    }

}
