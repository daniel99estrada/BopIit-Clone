using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{   
    public float health;

    public int increase;

    public int decrease;

    public int maxHealth;

    void Start()
    {
        health = 50;
    }

    public void Inscrease()
    {
        health += increase;

        if(maxHealth < health)
        {   
            health = maxHealth;
        }
        
        Debug.Log(health);
    }

    public void Decrease()
    {
        health -= decrease;

        if(health < 0)
        {
            health = 0;
        }
        Debug.Log(health);
    }
}
