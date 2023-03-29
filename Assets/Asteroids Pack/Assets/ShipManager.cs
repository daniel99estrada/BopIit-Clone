using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{   
    [System.Serializable]
    public class Ship 
    {
        public Transform spawnPoint;
        public GameObject bullet;
        public GameObject ship;
    }

    public int currentIndex = 0;
    public float baseSpeed;

    private Ship activeShip;
    public List<Ship> ships = new List<Ship>();

    void Start()
    {
        foreach (Ship ship in ships)
        {   
            ship.ship.GetComponent<Renderer>().enabled = false;
        }

        activeShip = ships[0];
        activeShip.ship.GetComponent<Renderer>().enabled = true;
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
        GameObject bullet = Instantiate(activeShip.bullet, activeShip.spawnPoint.position, Quaternion.identity);
    }

}
