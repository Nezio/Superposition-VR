using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Signal signal;

    public float openDistance = 1.8f;
    public float openSpeed = 2f;

    private GameObject DoorLeft;
    private GameObject DoorRight;
    private float defaultX;

    private void Start()
    {
        // get door sides
        foreach (Transform child in transform)
        {
            if (child.name == "DoorLeft")
            {
                DoorLeft = child.gameObject;
            }

            if (child.name == "DoorRight")
            {
                DoorRight = child.gameObject;
            }
        }

        defaultX = Mathf.Abs(DoorLeft.transform.localPosition.x);

    }

    private void Update()
    {
        if(signal != null && signal.isActive)
        {
            // open left door
            if (DoorLeft.transform.localPosition.x < openDistance)
            {
                float offset = openSpeed * Time.deltaTime;
                float newPos = Mathf.Min(DoorLeft.transform.localPosition.x + offset, openDistance);
                DoorLeft.transform.localPosition = new Vector3(newPos, DoorLeft.transform.localPosition.y, DoorLeft.transform.localPosition.z);
            }

            // open right door
            if (DoorRight.transform.localPosition.x > -openDistance)
            {
                float offset = openSpeed * Time.deltaTime;
                float newPos = Mathf.Max(DoorRight.transform.localPosition.x - offset, -openDistance);
                DoorRight.transform.localPosition = new Vector3(newPos, DoorRight.transform.localPosition.y, DoorRight.transform.localPosition.z);
            }

        }
        else
        {
            // close left door
            if (DoorLeft.transform.localPosition.x > defaultX)
            {
                float offset = openSpeed * Time.deltaTime;
                float newPos = Mathf.Max(DoorLeft.transform.localPosition.x - offset, defaultX);
                DoorLeft.transform.localPosition = new Vector3(newPos, DoorLeft.transform.localPosition.y, DoorLeft.transform.localPosition.z);
            }

            // close right door
            if (DoorRight.transform.localPosition.x < -defaultX)
            {
                float offset = openSpeed * Time.deltaTime;
                float newPos = Mathf.Min(DoorRight.transform.localPosition.x + offset, -defaultX);
                DoorRight.transform.localPosition = new Vector3(newPos, DoorRight.transform.localPosition.y, DoorRight.transform.localPosition.z);
            }

        }
    }


}
