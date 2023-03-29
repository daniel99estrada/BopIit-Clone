using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastAsteroid : MonoBehaviour, IActor
{
    public float elapsedTime = 0; 
    public float startValue = 10;
    public float endValue = 1;
    public float duration = 2;

    public float minScale = 1f;
    public float maxScale = 3;

    // public float minSpeedFactor = 0.6f;
    // public float maxSpeedFactor = 3; 
    public float deaccelerationPoint = 100;

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
        float scale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(scale, scale, scale);
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
        Debug.Log("Explosion");
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(explosion, 4.0f);
    }
}

