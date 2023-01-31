using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{   
    [SerializeField]
    private float patternCountdownTime;
    private float patternCountdown;

    [SerializeField]
    private float reduceHealthCountdownTime;
    private float reduceHealthCountdown;   

    Health playerHealth; 

    void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
    }

    void NewPatternCountdown()
    {
        patternCountdown -= Time.deltaTime;

        if (patternCountdown <= 0)
        {
            patternCountdown = patternCountdownTime;
        }
    }
    
    void ReduceHealthCountdown()
    {
        patternCountdown -= Time.deltaTime;

        if (reduceHealthCountdown <= 0)
        {   
            playerHealth.Decrease();

            reduceHealthCountdown = reduceHealthCountdownTime;
        }
    }
}
