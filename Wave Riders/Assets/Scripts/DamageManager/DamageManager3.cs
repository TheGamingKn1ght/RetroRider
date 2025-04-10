using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager3 : DamageHandler
{
    public override void HandleRequest(int request, GameObject player)
    {
        if (request < 41)
        {
            System.Random rand = new System.Random();
            int partInt = rand.Next(0, player.GetComponent<PlayerController>().DamageableObjects.Count);

            string part = player.GetComponent<PlayerController>().DamageableObjects[partInt].name;
            player.GetComponent<PlayerController>().DamageableObjects.RemoveAt(partInt);

            player.transform.Find(part).gameObject.AddComponent<Rigidbody>();
            player.transform.Find(part).transform.parent = null;

            if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request, player);
            }
        }

    }
}