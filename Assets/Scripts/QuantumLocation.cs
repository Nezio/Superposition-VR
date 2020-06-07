using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumLocation : MonoBehaviour
{
    // Detects if object this script is attached to is visible by main camera.
    // Quantum location object has to have one quantum object as a sibling gameobject.

    [HideInInspector]
    public bool isVisible = false;
    [HideInInspector]
    public int numberOfPlayerTaggedObjectsInLocation = 0;

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

        // only collapse quantum state if player is not touching or inside the quantum location
        if(numberOfPlayerTaggedObjectsInLocation <= 0)
        {
            quantumObject.CollapseQuantumState(gameObject);
        }
        
    }

    void OnBecameInvisible()
    {
        isVisible = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            numberOfPlayerTaggedObjectsInLocation++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            numberOfPlayerTaggedObjectsInLocation--;
        }

        if (numberOfPlayerTaggedObjectsInLocation <= 0 && gameObject == quantumObject.currentQuantumLocation)
        {
            quantumObjectGO.SetActive(false);
        }

    }



}
