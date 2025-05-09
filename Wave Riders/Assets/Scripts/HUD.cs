using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour, IChannel
{
    [SerializeField] private CanvasGroup DamageEffect;
    [SerializeField] private CanvasGroup DeathEffect;
    [SerializeField] private TMP_Text powerUpTextRef;
    [SerializeField] private TMP_Text coinTextRef;

    public static int powerupNum;
    public static int coinNum;

    // Start is called before the first frame update
    void Start()
    {
        HealthSystem.Singleton.AddObserver(this);
        DamageEffect.alpha = 0;
        DeathEffect.alpha = 0;
        powerupNum = 0;
        coinNum = 0;
    }

    void Update()
    {
        powerUpTextRef.text = powerupNum.ToString();
        coinTextRef.text = coinNum.ToString();
    }

    public void Updates(int newHealth)
    {
        if(newHealth <= 0)
        {
            DeathEffect.GetComponent<Animator>().Play("DeathAnimation");
        }
        else
        {
            DamageEffect.GetComponent<Animator>().Play("DamageEffect");
        }
        
    }

}
