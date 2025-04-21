using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5 : Level
{
    [SerializeField] private List<GameObject> obstacles;
    [SerializeField] private GameObject Jump;
    [SerializeField] private GameObject Shield;

    [SerializeField] private List<GameObject> CoinGroups;

    Vector3 obstacleDisplacement = new Vector3(25,0,0);

    // Start is called before the first frame update
    void Awake()
    {
        LevelID = 5;
        GetCoords();
        PlaceObstacles();
    }
    public override void PlaceObstacles()
    {
        System.Random rand = new System.Random();
        int obsInt = rand.Next(0, 2);

        if (obsInt == 1)
        {
            foreach (GameObject obstacle in obstacles)
            {
                obstacle.transform.position -= obstacleDisplacement;
            }
        }

        int powerUpInt = rand.Next(0, 3);

        Debug.Log(powerUpInt);

        if (powerUpInt == 1)
        {
            Jump.SetActive(true);
        }
        else if (powerUpInt == 2)
        {
            Shield.SetActive(true);
        }

        PlaceCoins(obsInt, powerUpInt);
    }

    public override void PlaceCoins(int obsInt, int puInt)
    {
        System.Random rand = new System.Random();
        int coinInt = rand.Next(0, 2);

        if(obsInt == 0)
        {
            if(puInt == 0)
            {
                CoinGroups[0].SetActive(true);
            }
        }
        else
        {
            CoinGroups[1].SetActive(true);
        }

        if(coinInt == 1)
        {
            CoinGroups[2].SetActive(true);
        }


    }

}
