using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Grid : MonoBehaviour
{   
    public float spawnInterval;
    public int z;
    public int ROWS;
    public int COLS;
    public float WIDTH;
    public float HEIGHT;
    public int ROW_RATIO;
    public int COL_RATIO;
    private float YOFFSET;
    private float XOFFSET;
    Transform player;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("SpawnActors", spawnInterval, spawnInterval);
    }

    public void SpawnActors()
    {   
        XOFFSET = - (ROWS * WIDTH)/2 + player.position.x;
        YOFFSET = - (COLS * HEIGHT)/2 + player.position.y;

        int n = ROW_RATIO;
        int[] pickedRows = Enumerable.Range(0, ROWS).OrderBy(x => Random.value).Take(n).ToArray();

        foreach (int row in pickedRows)
        {   
            n = COL_RATIO;
            int[] pickedColumns = Enumerable.Range(0, COLS).OrderBy(x => Random.value).Take(n).ToArray();

            foreach (int col in pickedColumns)
            {     
                float x = (row * WIDTH) + XOFFSET;
                float y = (col * HEIGHT) + YOFFSET;
                Vector3 position = new Vector3(x, y, z);

                ISpawner spawner = GetComponent<ISpawner>();

                if (spawner != null) 
                {
                    spawner.InstantiateObject(position); 
                } 
            }
        }
    }
}

