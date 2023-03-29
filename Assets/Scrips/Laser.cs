using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{   
    public float range;

    [Header("Ray Settings")]
    public bool ray;
    public float scaleFactor;
    public Vector3 targetScale;
    public float scaleSpeed;
    public string colliderTag;
    public float damage;

    public GameObject particleEffectPrefab;

    void Update()
    {   
        CheckRange();
    
        if (ray) ScaleRay();
    }

    void DestroyBullet()
    {
       gameObject.SetActive(false);
    }

    void CheckRange() 
    {
        if (transform.position.z > range)
        {    
            DestroyBullet();
        }
    }

    void ScaleRay()
    {   
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, scaleSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collision)
    {   
        IActor actor = collision.gameObject.GetComponent<IActor>();

        if (actor != null) 
        {
            actor.OnCollision();
            DestroyBullet();
        }
    }
}
