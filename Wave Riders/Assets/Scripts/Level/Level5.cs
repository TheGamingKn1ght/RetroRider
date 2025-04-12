using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5 : Level
{
    [SerializeField] private List<GameObject> obstacles;
    [SerializeField] private GameObject Jump;
    [SerializeField] private GameObject Shield;

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
    }
}
