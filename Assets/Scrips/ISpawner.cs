using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawner 
{
    void InstantiateObject(Vector3 position);

    void BuildObject(GameObject obj);
}
