using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    #region Singleton
    public static HealthSystem Singleton;
    
    public void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    [SerializeField] public int maxHealth;
    private int health;

    //Implementing List to announce health changes to any observers
    private List<IChannel> listeners = new List<IChannel>();
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    //setting up observers
    public void AddObserver(IChannel channel)
    {
        listeners.Add(channel);
    }
    public void RemoveObserver(IChannel channel)
    {
        listeners.Remove(channel);
    }

    //Applying and Announcing and health changes
    public void applyDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            health = 0;
        }
        foreach (var channel in listeners)
        {
            channel.Updates(health);
        }

    }
}
