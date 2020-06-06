using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGate : MonoBehaviour
{
    public Signal signal;

    private GameObject gate;
    private bool isActive = true;

    private void Start()
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.name == "Gate")
            {
                gate = child.transform.gameObject;
            }
        }
    }


    private void Update()
    {
        // if signal component is not there: use the gate as static object
        // if signal exists and is active
        if (signal != null && signal.isActive)
        {
            // deactivate gate if it's active
            if (isActive)
            {
                DeactivateGate();
            }
        }
        else
        {
            // signal doesn't exist or is not active

            if (!isActive)
            {
                ActivateGate();
            }
        }

    }

    private void ActivateGate()
    {
        gate.SetActive(true);
        isActive = true;
    }

    private void DeactivateGate()
    {
        gate.SetActive(false);
        isActive = false;
    }

}
