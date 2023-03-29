using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public float _width;
    public static float width;
    public GameObject particleEffectPrefab;

    void Awake()
    {
        width = _width;
    }
}
