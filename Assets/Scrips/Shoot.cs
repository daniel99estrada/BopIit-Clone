using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{   
    public GameObject prefab;
    public Transform spawnPoint;
    
    public void ShootLaser()
    {
        GameObject bullet = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}
