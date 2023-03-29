using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToShip : MonoBehaviour
{
    Transform player;
    public float speed;
    public bool contact = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {   
        if (contact)
        {
            MoveTowardsShip();
        }
    }

    public void MoveTowardsShip()
    {
        transform.Translate(player.position * speed * Time.deltaTime, Space.World);
    }
}
