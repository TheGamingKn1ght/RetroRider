using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : Level
{
    [SerializeField] private GameObject copLeft;
    [SerializeField] private GameObject copRight;
    [SerializeField] private List<GameObject> CoinGroups;

    [SerializeField] private GameObject Jump;
    [SerializeField] private GameObject Shield;

    // Start is called before the first frame update
    void Awake()
    {
        LevelID = 2;
        GetCoords();
        PlaceObstacles();
    }

    public override void PlaceObstacles()
    {
        System.Random rand = new System.Random();
        int carInt = rand.Next(0, 2);
        
        //Cop placement
        if(carInt == 1)
        {
            copLeft.SetActive(true);
        }
        else
        {
            copRight.SetActive(true);
        }

        //PowerUp
        int powerUpInt = rand.Next(0, 3);

        if (powerUpInt == 1)
        {
            Jump.SetActive(true);
        }
        else if (powerUpInt == 2)
        {
            Shield.SetActive(true);
        }

        PlaceCoins(carInt, powerUpInt);
    }

    public override void PlaceCoins(int obsInt, int puInt)
    {
        System.Random rand = new System.Random();
        int coinInt = rand.Next(0, 2);

        if (obsInt == 1 && coinInt == 1)
        {
            CoinGroups[1].SetActive(true);
        }

        if (obsInt == 0)
        {
            CoinGroups[0].SetActive(true);
        }

        if(puInt == 0)
        {
            CoinGroups[2].SetActive(true);
        }
    }
}
