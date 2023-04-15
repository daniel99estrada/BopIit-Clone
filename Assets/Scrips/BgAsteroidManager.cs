using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgAsteroidManager : Grid
{   
    public float spawnInterval;

    void Start ()
    {
        InvokeRepeating("SpawnActors", spawnInterval, spawnInterval);
    }

    public override void InstantiateObject(Vector3 position)
    {
        GameObject obj = GetComponent<BackgroundAsteroidPool>().SpawnFromPool(position, Quaternion.identity);
    }
}
