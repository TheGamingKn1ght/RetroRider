using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShieldPowerUp : MonoBehaviour,ICollectible
{
    private List<GameObject> ShieldMeshUnits = new List<GameObject>();

    private void Start()
    {
        int children = transform.childCount;

        for(int i = 0; i <= transform.childCount; i++)
        {
            ShieldMeshUnits.Add(this.transform.GetChild(i).gameObject);
        }
    }

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
        foreach(var child in ShieldMeshUnits)
        {
            child.SetActive(!child.activeSelf);
        }
    }
}
