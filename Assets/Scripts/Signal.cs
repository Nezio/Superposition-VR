using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    public bool isActive { get; private set; }

    private void Start()
    {
        isActive = false;
    }

    public void SetSignal()
    {
        isActive = true;
    }

    public void ResetSignal()
    {
        isActive = false;
    }
}
