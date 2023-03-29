using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteEnvironment : MonoBehaviour
{
    void OnBecameInvisible() 
    {   
        Destroy(gameObject);
    }
}
