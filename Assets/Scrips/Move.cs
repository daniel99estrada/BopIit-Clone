using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speedFactor = 1;
    public Vector3 direction = new Vector3(0,0,-1);
    private float speed;

    void Update()
    {
        MoveObject();
    }

    void MoveObject()
    {   
        speed = SpeedManager.speed * speedFactor;
        this.transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
    
    public void SetRandomValues(float min, float max)
    {
        speedFactor = Random.Range(min, max);
    }
}
