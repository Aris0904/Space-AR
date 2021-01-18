using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyImageTargetController : MonoBehaviour
{
    public Canvas myCanvas;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("spaceshipTarget"))
            return;

        if (other.gameObject.CompareTag("characterTarget"))
        {
            myCanvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!gameObject.CompareTag("spaceshipTarget"))
            return;

        if (other.gameObject.CompareTag("characterTarget"))
        {
            myCanvas.gameObject.SetActive(false);
        }
    }
}
