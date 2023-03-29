using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBase : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speedFactor = 1;
    public Vector3 direction = new Vector3(0,0,-1);
    private float speed;
    bool reachedEnd = false;
    
    void Update()
    {
        // MoveObject();
        // endReached();

    }

    void MoveObject()
    {   
        speed = SpeedManager.speed * speedFactor;
        this.transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    void endReached()
    {
        if (transform.position.z < 0 && !reachedEnd)
        {   
            transform.parent.GetComponent<SpawnEnvironment>().InstantiateActors();
        }
    }
}