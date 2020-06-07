using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuantumObject : MonoBehaviour
{
    public List<QuantumLocation> quantumLocations;
    public float appearChance = 0.5f;

    [HideInInspector]
    public GameObject currentQuantumLocation;

    private bool isVisible = false;


    private void Start()
    {
        currentQuantumLocation = null;

        // start invisible
        OnBecameInvisible();
        
    }

    void OnBecameVisible()
    {
        //Debug.Log(gameObject.name + " became visible (•_•)");

        isVisible = true;
    }

    void OnBecameInvisible()
    {

        //Debug.Log(gameObject.name + " became invisible");

        isVisible = false;

        // only hide quantum object if player not touching quantum location this object is in
        if(currentQuantumLocation == null || currentQuantumLocation.GetComponent<QuantumLocation>().numberOfPlayerTaggedObjectsInLocation <= 0)
        {
            HideQuantumObject();
        }
        
    }

    public void CollapseQuantumState(GameObject quantumLocationGO)
    {
        // collapse quantum state of the quantum object, forcing it do 'decide' if it's in the observed location or not

        // if quantum object is observed or active: do nothing
        if (isVisible || gameObject.activeSelf)
            return;

        // reminder in case of exception
        if (quantumLocations.Any(q => q == null))
        {
            Debug.Log("Did you forget to set the quantum locations in the quantum object?");
        }

        // if all locations are being observed: move quantum object to this location as it must be the last one (but not if there is only one quantum location)
        if (quantumLocations.Count > 1 && quantumLocations.All(q => q.isVisible))
        {
            //Debug.Log("All locations of a group are visible! Quantum oject should be visible now.");

            ShowQuantumObject(quantumLocationGO);
        }

        // all other cases: move with chance
        float random = Random.Range(0f, 1f);
        if (random < appearChance)
        {
            ShowQuantumObject(quantumLocationGO);
        }
    }

    private void ShowQuantumObject(GameObject quantumLocationGO)
    {
        Vector3 position = quantumLocationGO.transform.position;
        transform.position = position;
        gameObject.SetActive(true);

        currentQuantumLocation = quantumLocationGO;
    }

    private void HideQuantumObject()
    {
        gameObject.SetActive(false);

        currentQuantumLocation = null;
    }

}
