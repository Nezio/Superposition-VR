using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    public List<string> allowedTags;

    private UnityEvent actions;
    private GameObject pressurePlate;
    private Signal signal;

    private bool hasPressure = false;
    private bool isPressed = false;
    private bool alreadyPressed = false;
    private float pressSpeed = 0.2f;
    private float minY = -0.24f;
    private float defaultY;
    

    private void Start()
    {
        pressurePlate = transform.parent.gameObject;
        defaultY = pressurePlate.transform.localPosition.y;
        actions = transform.parent.parent.gameObject.GetComponent<PressurePlateActions>().actions;
        signal = transform.parent.parent.gameObject.GetComponent<Signal>();
    }

    private void Update()
    {
        if(isPressed && !alreadyPressed)
        {
            actions.Invoke();
            alreadyPressed = true;

            AudioManager.instance.PlayOneShot("PressurePlateActivate");
        }

        // if not already all the way up, restore it
        if (!hasPressure && pressurePlate.transform.localPosition.y < defaultY)
        {
            float offset = pressSpeed * Time.deltaTime;
            float newPos = Mathf.Min(pressurePlate.transform.localPosition.y + offset, defaultY);
            pressurePlate.transform.localPosition = new Vector3(pressurePlate.transform.localPosition.x, newPos, pressurePlate.transform.localPosition.z);
        }

        // set the signal
        if(isPressed)
        {
            signal.SetSignal();
        }
        else
        {
            signal.ResetSignal();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // if object that stepped on the button is allowed to press it
        if (allowedTags.Contains(other.tag))
        {
            hasPressure = true;

            // if not pressed all the way, press the plate down
            if(pressurePlate.transform.localPosition.y > minY)
            {
                float offset = pressSpeed * Time.deltaTime;
                float newPos = Mathf.Max(pressurePlate.transform.localPosition.y - offset, minY);
                pressurePlate.transform.localPosition = new Vector3(pressurePlate.transform.localPosition.x, newPos, pressurePlate.transform.localPosition.z);            
            }
            else
            {
                isPressed = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // did all objects that could press the plate leave it?
        bool pressurePlateClear = true;

        Collider[] colliders = Physics.OverlapBox(transform.position, transform.lossyScale / 2f);
        foreach(Collider collider in colliders)
        {
            if (allowedTags.Contains(collider.gameObject.tag))
            {
                pressurePlateClear = false;
            }
        }

        if (pressurePlateClear)
        {
            hasPressure = false;
            alreadyPressed = false;
            isPressed = false;
        }        
    }
}
