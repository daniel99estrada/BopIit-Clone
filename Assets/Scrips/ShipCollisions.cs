using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollisions : MonoBehaviour
{
    void OnTriggerEnter(Collider collision) 
    {
        if (collision.gameObject.tag == "Ring") 
        {   
            Debug.Log("RING collision");
        }
    }
}