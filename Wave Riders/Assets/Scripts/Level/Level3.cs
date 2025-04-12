using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : Level
{
    [SerializeField] private GameObject Jump;
    [SerializeField] private GameObject Shield;

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
    }
}
