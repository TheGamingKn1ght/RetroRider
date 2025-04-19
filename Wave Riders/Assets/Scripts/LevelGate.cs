using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LevelSpawner.gateCount++;
            LevelSpawner.previousLevels.Add(this.GetComponentInParent<Level>().gameObject);

            if (LevelSpawner.gateCount % 2 == 0)
            {
                if (LevelSpawner.gateCount == 2)
                {
                    LevelSpawner.DestroyPreviousLevels(1);
                }
                else
                {
                    LevelSpawner.DestroyPreviousLevels(2);
                }
            }
        }
    }
}
