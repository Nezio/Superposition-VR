using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AndGate : MonoBehaviour
{
    public List<Signal> inputSignals;

    private Signal outputSignal;

    private void Start()
    {
        outputSignal = gameObject.GetComponent<Signal>();
    }

    private void Update()
    {
        bool output = true;

        // if any signal is not active: output is 0
        foreach(Signal inputSignal in inputSignals)
        {
            if(!inputSignal.isActive)
            {
                output = false;
            }
        }

        if(output)
        {
            outputSignal.SetSignal();
        }
        else
        {
            outputSignal.ResetSignal();
        }
    }


}
