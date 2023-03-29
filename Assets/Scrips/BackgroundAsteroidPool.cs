using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAsteroidPool : MonoBehaviour
{   
    [System.Serializable]
    public class Pool 
    {
        public GameObject prefab;
        public int size;
    }
    
    public List<Pool> pools;
    public List<Queue<GameObject>> poolList;

    #region Singleton

    public static BackgroundAsteroidPool Instance;

    private void Awake()
    {
        // if (Instance == null) Instance = this;
    }

    #endregion

    void Start () 
    {
        poolList = new List<Queue<GameObject>>();

        foreach (Pool pool in pools)
        {   
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);

                obj.SetActive(false);
                
                ISpawner spawnManager = GetComponent<ISpawner>();
                if (spawnManager != null) 
                {
                    spawnManager.BuildObject(obj);
                }

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