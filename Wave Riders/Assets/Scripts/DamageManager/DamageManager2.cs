using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager2 : DamageHandler
{
    public override void HandleRequest(int request, GameObject player)
    {
        if (request < 61)
        {
            player.transform.Find("Smoke").gameObject.SetActive(true);

            if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request, player);
            }
        }

    }
}
