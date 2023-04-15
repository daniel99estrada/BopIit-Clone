using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{   
    // [System.Serializable]
    // public class Ship 
    // {
    //     public Transform spawnPoint;
    //     public GameObject bullet;
    //     public GameObject ship;
    // }

    public int currentIndex = 0;
    public float baseSpeed;

    public Ship activeShip;
    public List<Ship> ships = new List<Ship>();
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float health;
    public float decrease; 

    void Start()
    {
        // foreach (Ship ship in ships)
        // {   
        //     ship.ship.GetComponent<Renderer>().enabled = false;
        // }

        // ActivateShip(0);
    }

    void Update ()
    {
        health -= decrease * Time.deltaTime;

        if (health < 30) 
        {
            SpeedManager.Deaccelerate();
            health += 100;
        }
    }

    public void CycleObjects()
    {
        currentIndex = currentIndex == 0 ? 1 : 0;
        ActivateShip(currentIndex);
    }

    public void ActivateShip(int index)
    {
        activeShip.ship.GetComponent<Renderer>().enabled = false;
        activeShip = ships[index];
        activeShip.ship.GetComponent<Renderer>().enabled = true;
    }

    public void Shoot()
    {   
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
    }

    void OnTriggerEnter(Collider collider)
    {   
        if(collider.gameObject.tag == "Ring")
        {   
            GetComponent<Health>().Heal(1);
        }
        if(collider.gameObject.tag == "Asteroid")
        {
            GetComponent<Health>().TakeDamage(2);
        }
        if(collider.gameObject.tag == "EnemyLaser")
        {
            GetComponent<Health>().TakeDamage(3);
            Destroy(collider.gameObject);
        }
    }

}
