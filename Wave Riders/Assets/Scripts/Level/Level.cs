using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour, ILevel
{
    [SerializeField] public Transform StartCoords;
    [SerializeField] public Transform EndCoords;

    public int LevelID;

    // Start is called before the first frame update
    void Start()
    {
        GetCoords();
    }

    public void GetCoords()
    {
        //Index needs to be changed when real level is implemented
        StartCoords = this.transform.Find("StartCoords");
        EndCoords = this.transform.Find("EndCoords");
    }
    public virtual void PlaceObstacles()
    {
        Debug.Log("Placing Obstacles");
    }
}
