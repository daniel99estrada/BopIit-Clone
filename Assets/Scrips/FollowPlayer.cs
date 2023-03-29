using UnityEngine;

public class FollowPLayer : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        // Get the position of the target object
        Vector3 targetPos = target.position;

        // Set the y position to be the same as the object that this script is attached to
        targetPos.y = transform.position.y;

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * 1);
    }
}
