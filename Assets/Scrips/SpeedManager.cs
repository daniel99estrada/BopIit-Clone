using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager: MonoBehaviour
{   
    public float startingSpeed;
    public static float speed;
    public float minSpeed = 25;
    public float maxSpeed = 35;
    public static bool accelerate = false;
    public static bool deaccelerate = false;

    public float elapsedTime = 0; 
    public float startValue = 1;
    public float endValue = 1f;
    public float duration = 2;
    private float newSpeed;

    void Awake()
    {
        speed = startingSpeed;
    }
    void Update()
    {
        if (accelerate) 
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            newSpeed = Mathf.Lerp(minSpeed, maxSpeed, t);
            speed = newSpeed;
        }

        else
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            newSpeed = Mathf.Lerp(maxSpeed, minSpeed, t);
            speed = newSpeed;
        }   
    }

    public static void Accelerate()
    {   
        accelerate = true;
    }

    public static void Deaccelerate ()
    {
        accelerate = false; 
    }
}
