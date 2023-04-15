using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{   
    private Health health; 
    private Transform bar1;
    private Transform bar2;
    private float healthFactor;
    public float maxSize = 10;

    void Awake()
    {   
        health = transform.parent.GetComponent<Health>();
        health.OnHealthChanged += UpdateHealthBar;
    }

    void Start()
    {
        bar1 = transform.GetChild(0);
        bar2 = transform.GetChild(1);   
    }

    public void UpdateHealthBar(int currentHealth) {

        healthFactor = currentHealth / 100.0f;
        if (healthFactor <= 0) 
        {
            healthFactor = 0;
            VFX.Instance.SpawnVFX("explosion", transform.position); 
            Destroy(transform.parent.gameObject);
        }

        float x = maxSize * healthFactor;
        Vector3 position1 = new Vector3(-(maxSize - x) / 2, transform.position.y, transform.position.z);
        Vector3 position2 = new Vector3(x / 2, transform.position.y, transform.position.z);
        Vector3 scale1 = new Vector3(x, 1.6f, 3.0f);
        Vector3 scale2 = new Vector3(maxSize - x, 1.6f, 3.0f);

        bar1.localScale = scale1;
        bar1.localPosition = position1;
        bar2.localPosition = position2;
        bar2.localScale = scale2;
    }
}
