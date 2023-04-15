using UnityEngine;

[CreateAssetMenu(fileName ="Ship", menuName = "ShipMenu")]
public class Ship : ScriptableObject
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public GameObject ship;
    public float speed;
}