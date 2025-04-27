using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Transform SpawnPoint;

    private float score;

    private Color OGcolor;

    #region Singleton
    public static ScoreCounter Singleton;

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

    private void Start()
    {
        OGcolor = this.GetComponent<TMP_Text>().color;
    }

    // Update is called once per frame
    void Update()
    {
        score = Mathf.RoundToInt((PlayerController.Singleton.transform.Find("Collider").transform.position.z - SpawnPoint.position.z) + HUD.coinNum);
        

        this.GetComponent<TMP_Text>().text = score.ToString();
    }

    public void AddToScore(int value)
    {
        score += value;
        if (value < 0)
        {
            StartCoroutine(TextDamageEffect());
        }
    }

    private IEnumerator TextDamageEffect()
    {
        this.GetComponent<TMP_Text>().color = Color32.Lerp(OGcolor, Color.red, 0.5f);
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<TMP_Text>().color = Color32.Lerp(Color.red, OGcolor,1);
    }
}
