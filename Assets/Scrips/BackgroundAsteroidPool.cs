using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAsteroidPool : MonoBehaviour
{   
    // [System.Serializable]
    // public class Pool 
    // {
    //     public GameObject prefab;
    //     public int size;
    // }
    
    // public List<Pool> pools;
    public AsteroidPrefabsScriptableObject asteroids;
    public List<Queue<GameObject>> poolList;

    #region Singleton

    public static BackgroundAsteroidPool Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    #endregion

    void Start () 
    {
        poolList = new List<Queue<GameObject>>();

        foreach (GameObject prefab in asteroids.prefabs)
        {   
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < 1000; i++)
            {
                GameObject obj = Instantiate(prefab);

                obj.AddComponent<Move>();
                obj.transform.SetParent(this.transform);
                obj.AddComponent<BackGroundAsteroids>();
                obj.SetActive(false);
    
                objectPool.Enqueue(obj);
            }

            poolList.Add(objectPool);
        }
    }
    
    public GameObject SpawnFromPool (Vector3 position, Quaternion rotation)
    {   
        int randomIndex = Random.Range(0, poolList.Count);

        GameObject objectToSpawn = poolList[randomIndex].Dequeue();
        
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();

        if(pooledObject != null)
        {
            pooledObject.OnObjectSpawn();
        }

        poolList[randomIndex].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}