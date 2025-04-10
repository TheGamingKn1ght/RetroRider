using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandlerManager : MonoBehaviour, IChannel
{
    [SerializeField] private GameObject player;

    private DamageHandler handler1;
    private DamageHandler handler2;
    private DamageHandler handler3;
    private DamageHandler handler4;

    // Start is called before the first frame update
    void Start()
    {
        HealthSystem.Singleton.AddObserver(this);

        handler1 = new DamageManager1();
        handler2 = new DamageManager2();
        handler3 = new DamageManager3();
        handler4 = new DamageManager4();

        handler1.SetNext(handler2);
        handler2.SetNext(handler3);
        handler3.SetNext(handler4);
    }

    public void Updates(int newHealth)
    {
        handler1.HandleRequest(newHealth, player);
    }
}
