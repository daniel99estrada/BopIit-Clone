using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFast : MonoBehaviour
{
    [Header("Deacceleration Settings")]
    public float startValue = 10;
    public float endValue = 1;
    public float duration = 2;
    public float deaccelerationPoint = 100;
    private float elapsedTime = 0; 

    [Header("Movement Settings")]
    public float speedFactor = 1;
    public Vector3 direction = new Vector3(0,0,-1);
    private float speed;

    public void SetValues(MoveFastScriptableObject settings)
    {   
        speedFactor = settings.startValue;
        startValue = settings.startValue;
        endValue = settings.endValue;
        duration = settings.duration;
        deaccelerationPoint = settings.deaccelerationPoint; 
    }

    void Update()
    {
        MoveObject();
        SlowDown();
    }

    void MoveObject()
    {   
        speed = SpeedManager.speed * speedFactor;
        this.transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    void SlowDown()
    {   
        if (transform.position.z < deaccelerationPoint)
        {   
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            speedFactor = Mathf.Lerp(startValue, endValue, t);
        }
    }
}