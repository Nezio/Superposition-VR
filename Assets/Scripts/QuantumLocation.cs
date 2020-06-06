using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumLocation : MonoBehaviour
{
    // Detects if object this script is attached to is visible by main camera.
    // Quantum location object has to have one quantum object as a sibling gameobject.

    [HideInInspector]
    public bool isVisible = false;

    private Renderer objectRenderer;
    private GameObject quantumObjectGO;
    private QuantumObject quantumObject;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        foreach (Transform child in transform.parent)
        {
            if (child.CompareTag("QuantumObject"))
            {
                quantumObjectGO = child.gameObject;
                quantumObject = quantumObjectGO.GetComponent<QuantumObject>();
            }
        }
    }

    void OnBecameVisible()
    {
        isVisible = true;

        quantumObject.CollapseQuantumState(gameObject);
    }

    void OnBecameInvisible()
    {
        isVisible = false;
    }


}
