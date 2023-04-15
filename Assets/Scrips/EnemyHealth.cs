using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IActor
{   
    [SerializeField]
    private GameObject healthBar;
    private Health health;
    public int damageAmount = 15;

    void Start()
    {
        health = GetComponent<Health>(); 
        
        InvokeRepeating("Shoot", 1.0f, 1.0f);
    }

    void Shoot()
    {
        GetComponent<Shoot>().ShootLaser();
    }

    public void TakeDamage()
    {   
        health.TakeDamage(damageAmount);
    }
}
