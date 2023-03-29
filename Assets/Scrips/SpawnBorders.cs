using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBorders : MonoBehaviour
{   
    public GameObject prefab;
    public float offset;
    public float startingPoint;
    public float distanceBetweenPawns;
    public float totalPawns;

    private float z;
    private float x;

    // Start is called before the first frame update
    void Start()
    {   
        SpawnBorder();
    }
    
    void SpawnBorder()
    {   
        z = startingPoint;

        for (int i = 0; i < totalPawns; i++)
        {   
            x = EnvironmentManager.width/2;
            InstantiateActors(x +  offset, 180);
            InstantiateActors(-x - offset, 0);
            z += distanceBetweenPawns;
        }
    }

    void InstantiateActors(float x, float yRot)
    {   
        float y = prefab.transform.position.y;
        Vector3 position = new Vector3(x, y, z);
        Quaternion rotation = Quaternion.Euler(0f, yRot, 0f);
        GameObject pawn = Instantiate(prefab, position, rotation);
        pawn.transform.SetParent(this.transform);
    }
}
