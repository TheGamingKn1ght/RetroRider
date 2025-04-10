using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageHandler
{
    public DamageHandler _nextHandler;

    public void SetNext(DamageHandler handler)
    {
        _nextHandler = handler;
    }

    public abstract void HandleRequest(int request, GameObject player);
}
