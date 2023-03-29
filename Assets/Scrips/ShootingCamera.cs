using UnityEngine;

public class ShootingCamera : MonoBehaviour
{
    public Vector3 shootingPosition;
    public Vector3 shootingRotation;
    public Vector3 movingPosition;
    public Vector3 movingRotation;
    Vector3 currentPosition;
    Vector3 currentRotation;
    Vector3 targetPosition;
    Vector3 targetRotation;
    public float lerpTime;

    private float currentLerpTime;
    private bool isLerping = false;

    Transform player;

    void Start()
    {   
        player = GameObject.FindGameObjectWithTag("Player").transform;

        currentPosition = shootingPosition;
        currentRotation = shootingRotation;

        currentPosition = transform.position;
        currentRotation = transform.rotation.eulerAngles;

        targetPosition = movingPosition;
        targetRotation = movingRotation;
    }
    public void StartLerp()
    {
        currentLerpTime = 0f;
        isLerping = true;
    }

    void Update()
    {
        if (isLerping)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                Vector3 tempP = currentPosition;
                Vector3 tempR = currentRotation;
                currentPosition = targetPosition;
                currentRotation = targetRotation;
                targetPosition = tempP;
                targetRotation = tempR;

                currentLerpTime = lerpTime;
                isLerping = false;
            }

            float t = currentLerpTime / lerpTime;
            Vector3 lerpedPosition = Vector3.Lerp(currentPosition, targetPosition, t);
            Vector3 lerpedRotation = Vector3.Lerp(currentRotation, targetRotation, t);

            transform.position = lerpedPosition + player.position;
            // transform.rotation = Quaternion.Euler(lerpedRotation + player.rotation.eulerAngles);
        }

        // transform.position = currentPosition + player.position;
    }
}
