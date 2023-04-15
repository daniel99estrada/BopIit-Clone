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
    public float minPitch = -15f;
    public float maxPitch = 15f;
    public float minRoll = -15;
    public float maxRoll = 15;

    private float speed;
    private float yaw;
    float pitch;
    float roll;
    public float yMin;
    public float yMax;


    float horizontal;
    float vertical;

    private float elapsedTime = 0.0f;
    public float speedFactor;

    void Start()
    {   
        speedFactor = startValue;
    }

    void Update()
    {   

        speed = SpeedManager.speed * speedFactor;
        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;
        // horizontal = Input.GetAxis("Horizontal");
        // vertical = Input.GetAxis("Vertical");

        Move();
        // Accelerate();
    }

    // void Accelerate()
    // {   
    //     elapsedTime += Time.deltaTime;

    //     if (Mathf.Abs(horizontal) > 0 || Mathf.Abs(vertical) > 0)
    //     {
    //         SpeedManager.Accelerate();
    //     }
    //     else
    //     {
    //         SpeedManager.Deaccelerate();
    //     }
    // }

    void Move()
    {   
        // Vector3 leftDirection = Vector3.left;
        // Vector3 rightDirection = Vector3.right;
        // Vector3 sideDirection = horizontal > 0 ? rightDirection : leftDirection;

        Vector3 movement = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

        transform.position = newPosition;
        
        if (horizontal == 0)
        {
            yaw = Mathf.Lerp(yaw, 0, resetSpeed * Time.deltaTime);
            roll = Mathf.Lerp(roll, 0, resetSpeed * Time.deltaTime);
        }
        else
        {
            yaw += horizontal * yawAmount * Time.deltaTime;
            yaw = Mathf.Clamp(yaw, minYaw, maxYaw);
            roll += vertical * rollAmount * Time.deltaTime;
            roll = Mathf.Clamp(roll, minRoll, maxRoll);
        }

        if (vertical == 0)
        {
            pitch = Mathf.Lerp(pitch, 0, resetSpeed * Time.deltaTime);

        }
        else
        {
            pitch += vertical * pitchAmount * Time.deltaTime;
            pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        }

        transform.localRotation = Quaternion.Euler(-pitch, yaw, -roll);

        // float pitch = Mathf.Lerp(0, pitchAmount, Mathf.Abs(vertical) * Mathf.Sign(vertical));
        // float roll = Mathf.Lerp(0, rollAmount, Mathf.Abs(horizontal) * -Mathf.Sign(horizontal));
        // transform.localRotation = Quaternion.Euler(Vector3.up * yaw + sideDirection * pitch + Vector3.forward * roll);

    }

}
