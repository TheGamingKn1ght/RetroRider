using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUp : MonoBehaviour, ICollectible
{
    [SerializeField] private GameObject Explosion;
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
            this.transform.Rotate(Vector3.right);
        }

    }

    public void Collect()
    {
        Transform coords = this.gameObject.transform;
        coords.position = new Vector3(coords.position.x, coords.position.y, coords.position.z);
        
        JumpBar.Singleton.AddPower(25);
        ScoreCounter.Singleton.AddToScore(10);
        AudioManager.instance.PlaySFX("PickUpExplosion");
        Instantiate(Explosion,coords.position,coords.rotation);
        Destroy(this.gameObject);
    }

}
