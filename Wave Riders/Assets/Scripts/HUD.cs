using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour, IChannel
{
    [SerializeField] private CanvasGroup DamageEffect;
    [SerializeField] private TMP_Text powerUpTextRef;

    public static int powerupNum;

    #region Singleton
    public static HUD Singleton;

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

    // Start is called before the first frame update
    void Start()
    {
        HealthSystem.Singleton.AddObserver(this);
        DamageEffect.alpha = 0;
    }

    void Update()
    {
        powerUpTextRef.text = powerupNum.ToString();
    }

    public void Updates(int newHealth)
    {
        DamageEffect.GetComponent<Animator>().Play("DamageEffect");
    }

}
