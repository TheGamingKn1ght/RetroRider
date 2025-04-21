using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : Level
{
    [SerializeField] private GameObject Jump;
    [SerializeField] private GameObject Shield;

    [SerializeField] private List<GameObject> CoinGroups;

    // Start is called before the first frame update
    void Awake()
    {
        LevelID = 3;
        GetCoords();
        PlaceObstacles();
    }
    public override void PlaceObstacles()
    {
        System.Random rand = new System.Random();
        int powerUpInt = rand.Next(0, 3);

        if (powerUpInt == 1)
        {
            Jump.SetActive(true);
        }
        else if(powerUpInt == 2)
        {
            Shield.SetActive(true);
        }

        PlaceCoins(0, powerUpInt);
    }

    public override void PlaceCoins(int obsInt, int puInt)
    {
        System.Random rand = new System.Random();
        int coinInt = rand.Next(0, 3);

        if (coinInt != 0)
        {
            CoinGroups[0].SetActive(true);
        }

        if (puInt == 1)
        {
            if (coinInt == 1)
            {
                CoinGroups[3].SetActive(true);
            }
            
            if(coinInt == 2)
            {
                CoinGroups[2].SetActive(true);
                CoinGroups[4].SetActive(true);
            }
        }
        else if (puInt == 2)
        {
            if (coinInt == 1)
            {
                CoinGroups[4].SetActive(true);
            }

            if (coinInt == 2)
            {
                CoinGroups[1].SetActive(true);
                CoinGroups[3].SetActive(true);
            }
        }
        else
        {
            if (coinInt == 1)
            {
                CoinGroups[1].SetActive(true);
                CoinGroups[4].SetActive(true);
            }

            if (coinInt == 2)
            {
                CoinGroups[2].SetActive(true);
                CoinGroups[3].SetActive(true);
            }
        }
    }
}
