using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    #region Singleton
    public static LevelSpawner Singleton;
    
    public void Awake()
    {
        nextSpawn = startPos.position;
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

    [SerializeField] private Transform startPos;
    [SerializeField] private Level startLevel;
    [SerializeField] private List<Level> levels = new List<Level>();
    public static int LvlLength = 20;

    GameObject tempLVL;
    private Vector3 nextSpawn;
    private Vector3 blockLength;
    private Quaternion spawnQ;
    private int tempInt;

    private int levelsSpawned;
    public static int gateCount;
    public static List<GameObject> previousLevels = new List<GameObject>();
    private static int levelsDestroyed = 0;

    // Start is called before the first frame update
    void Start()
    {
        tempLVL = Instantiate(startLevel.gameObject,startPos);
        blockLength = tempLVL.GetComponent<Level>().StartCoords.position - tempLVL.GetComponent<Level>().EndCoords.position;

    }
    private void Update()
    {
        if(LvlLength - levelsSpawned > 0)
        {
            nextSpawn -= blockLength;
            tempLVL = Instantiate(levels[GetRandomLevel()].gameObject, nextSpawn, spawnQ);
            levelsSpawned++;
        }
    }

    private int GetRandomLevel()
    {
        int lvlInt;
        
        do {
            
            System.Random rand = new System.Random();
            lvlInt = rand.Next(0, levels.Count);

        } while (lvlInt == tempInt);

        tempInt = lvlInt;
        return lvlInt;

    }

    public static void DestroyPreviousLevels(int toDestroy)
    {
        for (int i = 0; i < toDestroy; i++)
        {
            Destroy(previousLevels[levelsDestroyed]);
            levelsDestroyed++;
            //previousLevels.RemoveAt(i);
        }
        LvlLength += 2;
    }
}
