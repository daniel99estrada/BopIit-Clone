using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{   
    public int maxHealth = 100;
    public float healthFactor;
    private float currentHealth;

    public GameObject particleEffectPrefab;
    public GameObject healthBar;
    private HealthBar healthBarScript;

    void Awake()
    {
        currentHealth = maxHealth;
        
        healthBarScript = healthBar.GetComponent<HealthBar>(); 
        healthBar.SetActive(false);      
    }

    public void TakeDamage(float decrease)
    {   
        currentHealth -= decrease;
        healthFactor = currentHealth/maxHealth;
        healthBar.SetActive(true);
        healthBarScript.ScaleBars(healthFactor);

        if(currentHealth < 0) {
            Destroy();
        }    
        healthFactor = currentHealth/maxHealth; 
        Debug.Log("Current health: " + currentHealth);
    }

    public void Destroy()
    {
        Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
        // Destroy(this.gameObject);
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = new Vector3(player.position.x, player.position.y, 200);
        currentHealth = maxHealth;
    }
}
