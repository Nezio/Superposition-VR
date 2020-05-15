using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    private Camera mainCamera;
    private Transform hand;
    private Rigidbody rigidbody;
    private bool isHeld = false;
    private float throwForce = 5f;

    private void Start()
    {
        mainCamera = Camera.main;

        // initialize hand gameobject
        foreach (Transform child in mainCamera.transform)
        {
            Debug.Log(child.name);
            if (child.name == "Hand")
            {
                hand = child;
            }
        }

        rigidbody = gameObject.GetComponent<Rigidbody>();

    }

    public void EventClick()
    {
        Debug.Log("click");

        if(isHeld)
        {
            Throw();
        }
        else
        {
            PickUp();
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Drop();
    }

    private void PickUp()
    {
        isHeld = true;
        rigidbody.useGravity = false;
        transform.SetParent(hand);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    private void Drop()
    {
        isHeld = false;
        rigidbody.useGravity = true;
        transform.SetParent(null);
    }

    private void Throw()
    {
        Drop();
        rigidbody.AddForce(mainCamera.transform.forward*throwForce, ForceMode.Impulse);
    }

    
}
