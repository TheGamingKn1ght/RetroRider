using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : Level
{
    [SerializeField] private GameObject puddle;

    [SerializeField] private List<GameObject> CoinGroups;
    // Start is called before the first frame update
    void Awake()
    {
        LevelID = 4;
        GetCoords();
        PlaceObstacles();
    }
    public override void PlaceObstacles()
    {
        System.Random rand = new System.Random();
        int obsInt = rand.Next(0, 2);

        if (obsInt == 1)
        {
            puddle.SetActive(true);
        }

        PlaceCoins(obsInt, 0);
    }

    public override void PlaceCoins(int obsInt, int puInt)
    {
        System.Random rand = new System.Random();
        int coinInt = rand.Next(0, 3);

        if (coinInt == 1)
        {
            CoinGroups[2].SetActive(true);
        }

        if (obsInt == 0 && coinInt == 2)
        {
            CoinGroups[1].SetActive(true);
            CoinGroups[2].SetActive(true);
        }

        if (obsInt == 1 && coinInt == 1)
        {
            CoinGroups[0].SetActive(true);
        }
        
    }
}
