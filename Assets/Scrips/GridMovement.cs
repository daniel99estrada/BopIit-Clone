using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    private float speed = 0;
    Vector3 direction = new Vector3(0,0,-1);
    ActorManager actorManager;
    bool canBuild = true;

    void Start()
    {   
        actorManager = transform.parent.GetComponent<ActorManager>();
    }
    void Update()
    {    
        speed = actorManager.speed;

        this.transform.Translate(direction * speed * Time.deltaTime, Space.World);

        Build();
    }

    void Build()
    {
        if (transform.position.z < -20 && canBuild) 
        {
            Destroy(this.gameObject);
            actorManager.SpawnGrid();
            canBuild = false;
        }
    }


}
