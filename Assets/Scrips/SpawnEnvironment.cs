using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnvironment : MonoBehaviour
{   

    [Header("Pawn Instantiation Settings")]
    public List<GameObject> prefabs;    
    private float minX;
    private float maxX;
    public float startingPoint;
    public float interval;

    [Header("Wave Settings")]
    public bool spawnWave;
    public float totalPawns;
    public float distanceBetweenPawns;

    [Header("Moving Settings")]
    public float speedFactor;

    [Header("Base Health Bar")]
    public GameObject healthBarPrefab;
    public float healthBarHeight;

    public Transform player;
    private float z;



    void Awake()
    {   
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {   
        z = startingPoint;
        // InstantiateActors();
        if (spawnWave) {
            SpawnWave();
        }
        else
        {   
            InvokeRepeating("InstantiateActors",interval, interval);
        }

    }

    void Update()
    {   
        Move();
    }

    void SpawnWave()
    {   
        z = startingPoint;

        for (int i = 0; i < totalPawns; i++)
        {   
            InstantiateActors();
            z += distanceBetweenPawns;
        }
    }

    public void InstantiateActors()
    {   
        // Select random Prefab.
        GameObject prefab = prefabs[Random.Range(0, prefabs.Count)];

        // Select spawn position.
        maxX = EnvironmentManager.width/2;
        minX = -maxX; 
        float x = Random.Range(minX, maxX) + player.position.x;
        float y = prefab.transform.position.y;
        Vector3 position = new Vector3(x, y, z);
        
        Quaternion randRotation = RandomYRotation();
        GameObject pawn = Instantiate(prefab, position, randRotation);
        pawn.transform.SetParent(this.transform);
        pawn.tag = "Base";


        // Add Scripts to GameObject
        pawn.AddComponent<DeleteEnvironment>();
        pawn.AddComponent<DestroyScript>();
        pawn.AddComponent<Health>();
        // pawn.AddComponent<MoveBase>();

        // Spawn Health Bar 
        Vector3 healthBarPosition = new Vector3(x, healthBarHeight, z);
        GameObject healthBar = Instantiate(healthBarPrefab, healthBarPosition, Quaternion.identity);
        healthBar.transform.SetParent(pawn.transform);

        pawn.GetComponent<Health>().healthBar = healthBar;
    }


    public static Quaternion RandomYRotation()
    {
        float randomYRotation = Random.Range(0f, 360f);
        Quaternion rotation = Quaternion.identity;
        rotation.eulerAngles = new Vector3(0f, randomYRotation, 0f);
        return rotation;
    }

    void Move()
    {
        Vector3 direction = new Vector3(0,0,-1);
        this.transform.Translate(direction * speedFactor * SpeedManager.speed * Time.deltaTime, Space.World);
    }
}
