using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
    public Transform target;

    public float smoothSpeed;
    public Vector3 offset;
    public bool LookAtTarget;
    public Vector3 randPosition = new Vector3(0, 0, 0);
    Vector3 desiredPosition;

    void Start() 
    {
        InvokeRepeating("Shoot", 1.0f, 1.0f);
    }
    private void LateUpdate()
    {
        desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        if (LookAtTarget) transform.LookAt(target);
    }

    void Shoot()
    {
        GetComponent<Shoot>().ShootLaser();
    }

    void SwitchTarget() 
    {   
        int x = Random.Range(0, 10) - 5;
        int y = Random.Range(0, 3);
        randPosition = new Vector3(x, y, 0);
        Invoke("ResetTarget", 2.0f);
    }

    void ResetTarget()
    {
        randPosition = new Vector3(0, 0, 0);
        Invoke("SwitchTarget", 2.0f);
    }

    // public float speed = 1f; // The speed at which the enemy moves
    // public float waitTimeMin = 1f; // The minimum amount of time the enemy waits before moving again
    // public float waitTimeMax = 5f; // The maximum amount of time the enemy waits before moving again
    // public float intervalMin = 3f; // The minimum amount of time between each movement cycle
    // public float intervalMax = 10f; // The maximum amount of time between each movement cycle

    // private Vector3 originalPosition; // The enemy's original position
    // private Vector3 targetPosition; // The position the enemy is moving towards
    // private bool movingToTarget = false; // Whether the enemy is currently moving towards the target position
    // private float currentWaitTime = 0f; // The current amount of time the enemy has been waiting
    // private float currentInterval = 0f; // The current amount of time until the next movement cycle

    // public Transform player;
    // public Vector3 offset;
    // public float smoothSpeed;

    // void Start () {
    //     originalPosition = player.position + offset;
    //     targetPosition = originalPosition;
    //     currentInterval = Random.Range(intervalMin, intervalMax);
    // }

    // void Update () {
    //     if (movingToTarget) 
    //     {
    //         Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    //         transform.position = smoothedPosition;

    //         if (transform.position == targetPosition) 
    //         {
    //             // Start waiting
    //             movingToTarget = false;
    //             currentWaitTime = Random.Range(waitTimeMin, waitTimeMax);
    //         }
    //     } 
    //     else 
    //     {
    //         // Wait
    //         currentWaitTime -= Time.deltaTime;
    //         if (currentWaitTime <= 0f) {
    //             // Start moving back to the original position
    //             movingToTarget = true;
    //             targetPosition =  GetRandomPosition();
    //         }
    //     }
    //     // Update the current interval
    //     currentInterval -= Time.deltaTime;
    //     if (currentInterval <= 0f) {
    //         // Start a new movement cycle
    //         currentInterval = Random.Range(intervalMin, intervalMax);
    //         movingToTarget = true;
    //         // Calculate a new target position within the movement range
    //         targetPosition = originalPosition;

    //     }
    // }

    // Vector3 GetRandomPosition() 
    // {
    //     float xRange = Random.Range(originalPosition.x - 10f, originalPosition.x + 10f);
    //     float yRange = Random.Range(originalPosition.y - 10f, originalPosition.y + 10f);
    //     return new Vector3(xRange, yRange, originalPosition.z);
    // }
}
