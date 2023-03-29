using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgAsteroidManager : MonoBehaviour, ISpawner
{   
    // [Header("Wave Instantiation Settings")]
    // public float spawnInterval;

    // public float minScale;
    // public float maxScale;

    // public float minSpeedFactor;
    // public float maxSpeedFactor; 

    void Start ()
    {
        // player = GameObject.FindGameObjectWithTag("Player").transform;
        // InvokeRepeating("SpawnWave", spawnInterval, spawnInterval);
    }

    public void InstantiateObject(Vector3 position)
    {
        GameObject obj = GetComponent<BackgroundAsteroidPool>().SpawnFromPool(position, Quaternion.identity);
    }

    public void BuildObject(GameObject obj) 
    {   
        // obj.AddComponent<RandomTumble>();
        obj.AddComponent<Move>();
        obj.transform.SetParent(this.transform);
        obj.AddComponent<BackGroundAsteroids>();

        GameObject mesh = obj.transform.GetChild(0).gameObject;
        mesh.AddComponent<BoxCollider>();
        mesh.AddComponent<Rigidbody>();
        mesh.GetComponent<Rigidbody>().useGravity = false;
    }
}
