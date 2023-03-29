using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour, IActor
{
    public float elapsedTime = 0; 
    public float startValue = 8;
    public float endValue = 1;
    public float duration = 3;

    public float minScale = 1f;
    public float maxScale = 8;

    public float minSpeedFactor = 0.6f;
    public float maxSpeedFactor = 3; 
    public float deaccelerationPoint = 15;

    [Header("Movement Settings")]
    public float speedFactor;
    public Vector3 direction = new Vector3(0,0,-1);
    private float speed;
    public GameObject explosionPrefab;

    void Update()
    {
        MoveObject();
        Deaccelerate();
    }

    void MoveObject()
    {   
        speed = SpeedManager.speed * speedFactor;
        this.transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    void Start ()
    {
        speedFactor = startValue;
    }

    void Deaccelerate()
    {   
        elapsedTime += Time.deltaTime;

        if (transform.position.z < deaccelerationPoint)
        {   
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            speedFactor = Mathf.Lerp(startValue, endValue, t);
        }
    }
    
    void OnBecameInvisible() 
    {   
        Destroy(gameObject);
    }

    public void OnCollision()
    {
        Debug.Log("On Collision with Ring");
    }
}


