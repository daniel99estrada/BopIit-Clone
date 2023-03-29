using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSpawner : MonoBehaviour
{ 
    public GameObject prefab;
    public float startingPoint;
    public float xOffset;
    public float yOffset;
    public float zOffset;
    public float spawnInterval;
    Transform player;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("SpawnActors", spawnInterval, spawnInterval);
    }

    public GameObject InstantiateObject(Vector3 position)
    {           
        return Instantiate(prefab, position, Quaternion.identity);
    }

    public void SpawnActors() 
    {   
        GameObject parent = new GameObject("Ring Pattern");
        int[] dir = {0, 0};
        int[] newDir = {0, 0};

        float x =  player.position.x;
        float y = player.position.y;
        float z = startingPoint;

        int total = Random.Range(3, 5);

        for(int i = 0 ; i < total; i++) 
        {   
            int strip = Random.Range(4, 6);

            for (int j = 0; j < strip; j++) 
            {
                x += (dir[0] * xOffset);
                y += (dir[1] * yOffset);
                z += zOffset; 
                Vector3 position = new Vector3(x, y, z);
                GameObject obj = InstantiateObject(position);
                obj.transform.parent = parent.transform;
            }

            do
            {
                newDir[0] = Random.Range(-1,1); 
                newDir[1] = Random.Range(-1,1);
            }
            while (dir[0] == newDir[0] && dir[1] == newDir[0]);

            dir[0] = newDir[0];
            dir[1] = newDir[1];
        }
        parent.AddComponent<Ring>();
    }
}
