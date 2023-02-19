using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public void DestroyObject()
    {
        Transform parentTransform = transform.parent;
        if (parentTransform != null)
        {
            Vector3 spawnPosition = transform.localPosition;
            parentTransform.GetComponent<SpawnParticleEffect>().SpawnDestroyEffect(spawnPosition);
        }
        Destroy(gameObject);
    }
}
