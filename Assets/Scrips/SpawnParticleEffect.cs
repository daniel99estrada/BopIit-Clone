using UnityEngine;

public class SpawnParticleEffect : MonoBehaviour
{   
    public GameObject particleEffectPrefab;

    public void SpawnDestroyEffect(Vector3 spawnPosition)
    {
        Instantiate(particleEffectPrefab, spawnPosition, Quaternion.identity);
        Debug.Log("SpawnDestroyEffect");
    }
}

