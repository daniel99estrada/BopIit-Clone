using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundAsteroids : MonoBehaviour, IPooledObject, IActor
{  
    public float minScale = 0.6f;
    public float maxScale = 4;

    public float minSpeedFactor = 0.6f;
    public float maxSpeedFactor = 3; 

    public void OnObjectSpawn()
    {   
        GetComponent<Move>().SetRandomValues(minSpeedFactor, maxSpeedFactor);
        RandomizeScale(); 
    }
    public void RandomizeScale()
    {
        float randomScale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(randomScale, randomScale, randomScale);
    }
    public void OnCollision()
    {   
        Debug.Log("Explosion");
    }
}