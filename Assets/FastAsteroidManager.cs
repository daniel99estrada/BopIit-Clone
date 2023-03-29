using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastAsteroidManager : MonoBehaviour, ISpawner
{   
    public List<GameObject> prefabs;
    Transform player;

    public void InstantiateObject(Vector3 position)
    {    
        int randomIndex = Random.Range(0, prefabs.Count);

        GameObject obj = Instantiate(prefabs[randomIndex], position, Quaternion.identity);
        BuildObject(obj);
    }

    public void BuildObject(GameObject obj) 
    {   
        obj.transform.SetParent(this.transform);
        obj.AddComponent<FastAsteroid>();
    }
}
