using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    private Signal signal;

    private void Start()
    {
        signal = transform.parent.gameObject.GetComponent<Signal>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            signal.SetSignal();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            signal.ResetSignal();
        }
    }


}
