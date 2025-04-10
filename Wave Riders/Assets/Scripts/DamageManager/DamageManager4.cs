using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager4 : DamageHandler
{
    public override void HandleRequest(int request, GameObject player)
    {
        if (request < 21)
        {
            player.transform.Find("Fire").gameObject.SetActive(true);

            if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request, player);
            }
        }

    }
}
