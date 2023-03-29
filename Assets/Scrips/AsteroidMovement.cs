using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{   
    private float speed = 0;
    public float speedIncreaseFactor;
    Vector3 direction = new Vector3(0,0,-1);
    ActorManager actorManager;

    void Start()
    {   
        actorManager = transform.parent.GetComponent<ActorManager>();
    }
    void Update()
    {    
        speed = actorManager.speed;

        this.transform.Translate(direction * speed * Time.deltaTime, Space.World);

        if (transform.position.z < -20) Destroy(this.gameObject);
    }
}
