using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Transform parent;
    private Transform bar1;
    private Transform bar2;
    private float healthFactor;
    float maxSize = 10;

    void Awake()
    {   
        bar1 = transform.GetChild(0);
        bar2 = transform.GetChild(1);   
        // bar1.GetComponent<Renderer>().enabled = false;
        // bar2.GetComponent<Renderer>().enabled = false;
        Deactivate(); 
    }

    public void ScaleBars(float healthFactor) {

        if (healthFactor < 0) 
        {
            healthFactor = 0;
            Debug.Log("Health factor: " + healthFactor);
            Deactivate();
            // Invoke("Deactivate", 0.5f); 

        };
        float x = maxSize * healthFactor;
        Vector3 position1 = new Vector3(-(maxSize - x) / 2, transform.position.y, transform.position.z);
        Vector3 position2 = new Vector3(x / 2, transform.position.y, transform.position.z);
        Vector3 scale1 = new Vector3(x, 1.6f, 3.0f);
        Vector3 scale2 = new Vector3(maxSize - x, 1.6f, 3.0f);

        bar1.localScale = scale1;
        bar1.localPosition = position1;
        bar2.localPosition = position2;
        bar2.localScale = scale2;
        bar1.GetComponent<Renderer>().enabled = true;
        bar2.GetComponent<Renderer>().enabled = true;
    }
    
    void Deactivate () 
    {
        bar1.GetComponent<Renderer>().enabled = false;
        bar2.GetComponent<Renderer>().enabled = false;
    }
}
