using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipMovement : MonoBehaviour
{   
    [Header ("Joystick Prefab")]
    public Joystick joystick;


    [Header ("Acceleration")]
    public float startValue;
    public float endValue;
    public float duration;
    float accelTime;
    
    [Header ("Rotation")]
    public float yawAmount;
    public float rollAmount;
    public float pitchAmount;
    public float resetSpeed;
    public float minYaw = -15f;
    public float maxYaw = 15f;

    private Rigidbody rb;
    private float speed;
    private float yaw;
    private bool canMove = true;
    public float yMin;
    public float yMax;


    float horizontal;
    float vertical;

    private float elapsedTime = 0.0f;
    float speedFactor;

    void Start()
    {   
        speedFactor = startValue;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {   
        speed = SpeedManager.speed * speedFactor;
        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;

        Move();
        // Accelerate();
    }

    void Accelerate()
    {   
        elapsedTime += Time.deltaTime;

        if (Mathf.Abs(horizontal) > 0 || Mathf.Abs(vertical) > 0)
        {
            float t = Mathf.Clamp01(elapsedTime / duration);
            speedFactor = Mathf.Lerp(startValue, endValue, t);
            SpeedManager.speed *= speedFactor;

        }
        else
        {
            float t = Mathf.Clamp01(elapsedTime / duration);
            speedFactor = Mathf.Lerp(endValue, startValue, t);
            SpeedManager.speed *= speedFactor;
        }
    }

    void Move()
    {   
        if (!canMove)
        {
            return;
        }

        Vector3 leftDirection = Vector3.left;
        Vector3 rightDirection = Vector3.right;
        Vector3 sideDirection = horizontal > 0 ? rightDirection : leftDirection;

        Vector3 movement = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

        // Limit the ship's movement between yMin and yMax values
        // float newY = Mathf.Clamp(newPosition.y, yMin, yMax);
        // newPosition.y = newY;

        transform.position = newPosition;

        if (horizontal == 0)
        {
            yaw = Mathf.Lerp(yaw, 0, resetSpeed * Time.deltaTime);
        }
        else
        {
            yaw += horizontal * yawAmount * Time.deltaTime;
            yaw = Mathf.Clamp(yaw, minYaw, maxYaw);
        }

        float pitch = Mathf.Lerp(0, pitchAmount, Mathf.Abs(vertical) * Mathf.Sign(vertical));
        float roll = Mathf.Lerp(0, rollAmount, Mathf.Abs(horizontal) * -Mathf.Sign(horizontal));
        transform.localRotation = Quaternion.Euler(Vector3.up * yaw + sideDirection * pitch + Vector3.forward * roll);
    }

}
