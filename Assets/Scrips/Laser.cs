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

    void Update()
    {   
        CheckRange();
    
        if (ray) ScaleRay();
    }

    void CheckRange() 
    {
        if (transform.position.z > range)
        {    
            Destroy(this.gameObject);
        }
    }

    void ScaleRay()
    {   
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, scaleSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {   
        
        GameObject vfx = VFX.Instance.SpawnVFX("laser", transform.position);
        IActor actor = collision.gameObject.GetComponent<IActor>();
        
        if (actor != null) 
        {   
            actor.TakeDamage();
            Destroy(this.gameObject);
        }  
    }
}
