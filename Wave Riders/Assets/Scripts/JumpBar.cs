using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpBar : MonoBehaviour
{

    [SerializeField] private Slider powerSlider;
    [SerializeField] private Slider easePowerSlider;
    private float Power;
    private float powerBarVal;
    private float lerpSpeed = 0.01f;
    public bool barFull;

    #region Singleton
    public static JumpBar Singleton;

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
        Power = 25;
        powerBarVal = Power / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (powerSlider.value != powerBarVal)
        {
            powerSlider.value = powerBarVal;
        }
        if (powerSlider.value != easePowerSlider.value)
        {
            easePowerSlider.value = Mathf.Lerp(easePowerSlider.value, powerBarVal, lerpSpeed);
        }

        if(Power >= 100)
        {
            Power = 100;
            barFull = true;
        }
        else
        {
            barFull = false;
        }
    }

    public void AddPower(float power)
    {
        Power += power;
        powerBarVal = Power / 100;
    }
}
