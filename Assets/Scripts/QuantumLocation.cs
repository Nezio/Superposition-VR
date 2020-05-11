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

    void Update()
    {
        // detect if object is visible, taking it's shadows in account
        /*if (objectRenderer.isVisible)
        {
            Debug.Log("Object is visible");
        }
        else
        {
            Debug.Log("Object is no longer visible");
        }*/

        // detect if object is visible, ignore shadows
        /*if (IsVisibleFrom(Camera.main))
        {
            Debug.Log("Visible");
        }
        else
        {
            Debug.Log("Not visible");
        }*/
    }

    /*private bool IsVisibleFrom(Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);

        return GeometryUtility.TestPlanesAABB(planes, objectRenderer.bounds);
    }*/

    void OnBecameVisible()
    {
        // don't do anything for scene camera
        //if (Camera.current && Camera.current.name == "SceneCamera")
        //    return;

        Debug.Log(gameObject.name + " became visible (•_•)");

        isVisible = true;

        quantumObject.CollapseQuantumState(gameObject);
    }

    void OnBecameInvisible()
    {
        // don't do anything for scene camera
        //if (Camera.current && Camera.current.name == "SceneCamera")
        //    return;

        Debug.Log(gameObject.name + " became invisible");

        isVisible = false;
    }
}
