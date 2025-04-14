using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour, IObstacle
{
    [SerializeField] private GameObject BreakableBarricade;
    private Quaternion spawnQ;
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
            HealthSystem.Singleton.applyDamage(5);
        }
        Transform coords = this.gameObject.transform;
        //Transform Pivot is off center so must adjust transform spawn
        coords.position = new Vector3(coords.position.x, coords.position.y - (float)12.99, coords.position.z - (float)2.24);
        Destroy(this.gameObject);
        Instantiate(BreakableBarricade, coords.position,coords.rotation);
        AudioManager.instance.PlaySFX("WallBreak");

    }
}
