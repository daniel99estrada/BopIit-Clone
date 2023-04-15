using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{   
    public GameObject explosion;
    public GameObject laser;
    public Dictionary<string, GameObject> vfxDictionary;

    #region Singleton

    public static VFX Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    #endregion

    void Start()
    {
        vfxDictionary = new Dictionary<string, GameObject>();
        vfxDictionary["explosion"] = explosion;
        vfxDictionary["laser"] = laser;
    }

    public GameObject SpawnVFX(string tag, Vector3 position)
    {
        return Instantiate(vfxDictionary[tag], position, Quaternion.identity);
    }

}
