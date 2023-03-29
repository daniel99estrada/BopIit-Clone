using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager: MonoBehaviour
{   
    public float startingSpeed;
    public static float speed;
    public static bool accelerate = false;
    public static bool deaccelerate = false;

    public float elapsedTime = 0; 
    public float startValue = 1;
    public float endValue = 1f;
    public float duration = 2;
    public float speedFactor = 1;

    void Awake()
    {
        speed = startingSpeed;
    }
    void Update()
    {
        speed *= speedFactor;
        if (accelerate) 
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            speedFactor = Mathf.Lerp(startValue, endValue,  t);
            if (speedFactor >= endValue) Invoke("Deaccelerate", 2.0f);
        }

        if (deaccelerate) 
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            speedFactor = Mathf.Lerp(endValue, startValue, t);
            if (speedFactor >= startValue) deaccelerate = false;
        }   
    }

    public static void Accelerate()
    {   
        accelerate = true; 
        Debug.Log("Accelerate manager");
    }

    public static void Deaccelerate ()
    {
        deaccelerate = true;
        Debug.Log("deaccelerate manager");
    }
}
