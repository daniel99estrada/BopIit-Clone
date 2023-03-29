using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class SpawnObjects : MonoBehaviour
{   
    [SerializeField] protected int z;
    [SerializeField] protected int ROWS;
    [SerializeField] protected int COLS;
    [SerializeField] protected float WIDTH;
    [SerializeField] protected float HEIGHT;
    [SerializeField] protected int ROW_RATIO;
    [SerializeField] protected int COL_RATIO;
    private float YOFFSET;
    private float XOFFSET;
    protected Transform player;

    public abstract void SpawnActor(Vector3 position);

    public void SpawnWave()
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

                SpawnActor(position);
            }
        }
    }
}

