using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorManager : MonoBehaviour
{   
    [Header("Speed settings")]
    public float increaseInterval;
    public float increaseValue;
    public float speed;

    [Header("GRID settings")]
    [SerializeField] private int rows;
    [SerializeField] private int cols;
    [SerializeField] private float width;
    [SerializeField] private float height;
    // [SerializeField] private float xOffset;
    // [SerializeField] private float yOffset;
    [SerializeField] private int colRatio;
    [SerializeField] private int rowRatio;

    [Header("Initial Wave settings")]
    public int initialZ;
    public int initialWaveAmount; 
    public int spaceBewteenInitialWaves;

    [Header("Actor Prefabs")]
    public GameObject gridPrefab;
    public GameObject actorPrefab;

    Transform player;
    private float z;

    void Start()
    {   
        z = initialZ;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        SpawnInitialWaves();
        InvokeRepeating("IncreaseSpeed", increaseInterval, increaseInterval);
        InvokeRepeating("SpawnGrid", increaseInterval, increaseInterval);
    }

    public void IncreaseSpeed()
    {
        speed += increaseValue;
    }

    public void SpawnGrid()
    {
        GameObject grid = Instantiate(gridPrefab, new Vector3(0,0, z), Quaternion.identity);
        grid.transform.SetParent(this.transform);
        // grid.GetComponent<Grid>().InstantiateActors(actorPrefab, rows, cols, width, height, rowRatio, colRatio);
    }

    void SpawnInitialWaves()
    {  
        for (int i = 0; i < initialWaveAmount; i++)
        {
            SpawnGrid();
            z += spaceBewteenInitialWaves;
        }
    }
}
