using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : Level
{
    [SerializeField] private List<GameObject> obstacles;
    [SerializeField] private List<GameObject> Powerup;
    [SerializeField] private List<GameObject> CoinGroups;

    Vector3 obstacleDisplacement = new Vector3(25, 0, 0);
    Vector3 boostDisplacement = new Vector3(28, 0, 0);

    // Start is called before the first frame update
    void Awake()
    {
        LevelID = 1;
        GetCoords();
        PlaceObstacles();
    }
    public override void PlaceObstacles()
    {
        System.Random rand = new System.Random();
        int obsInt = rand.Next(0, 2);
        int powerUpInt = rand.Next(0, 5);

        if (obsInt == 1)
        {
            foreach (GameObject obstacle in obstacles)
            {
                obstacle.transform.position += obstacleDisplacement;
            }

            if(powerUpInt != 0)
            {
                Powerup[powerUpInt].transform.position -= boostDisplacement;
                Powerup[powerUpInt].SetActive(true);
            }
        }

        Powerup[powerUpInt].SetActive(true);
        
        PlaceCoins(obsInt, powerUpInt);
    }

    public override void PlaceCoins(int obsInt, int puInt)
    {
        System.Random rand = new System.Random();
        int coinInt = rand.Next(0, 2);

        if (obsInt == 0 && puInt == 0)
        {
            CoinGroups[0].SetActive(true);
            if (coinInt == 0)
            {
                CoinGroups[1].SetActive(true);
                CoinGroups[2].SetActive(true);
            }
            else if (coinInt == 1)
            {
                CoinGroups[4].SetActive(true);
            }
        }
        else if(puInt == 0)
        {
            if (coinInt == 0)
            {
                CoinGroups[3].SetActive(true);
                CoinGroups[2].SetActive(true);
            }
            else if (coinInt == 1)
            {
                CoinGroups[4].SetActive(true);
            }
        }
    }
}
