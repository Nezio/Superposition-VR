using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuantumObject : MonoBehaviour
{
    public List<QuantumLocation> quantumLocations;
    public float appearChance = 0.5f;

    private bool isVisible = false;

    private void Start()
    {
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

        gameObject.SetActive(false);
    }

    public void CollapseQuantumState(GameObject quantumLocationGO)
    {
        // collapse quantum state of the quantum object, forcing it do 'decide' if it's in the observed location or not

        // if quantum object is observed: do nothing
        if (isVisible)
            return;

        // if all locations are beeing observed: move quantum object to this location as it must be the last one (but not if there is only one quantum location)
        if (quantumLocations.Count > 1 && quantumLocations.All(q => q.isVisible))
        {
            //Debug.Log("All locations of a group are visible! Quantum oject should be visible now.");

            ShowQuantumObject(quantumLocationGO.transform.position);
        }

        // all other cases: move with chance
        float random = Random.Range(0f, 1f);
        if (random < appearChance)
        {
            ShowQuantumObject(quantumLocationGO.transform.position);
        }
    }

    private void ShowQuantumObject(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }

}
