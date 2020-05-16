using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    public float throwForce = 5f;
    public float maxThrowForce = 10f;

    private Camera mainCamera;
    private Transform hand;
    private Rigidbody rigidbody;
    private bool isHeld = false;
    private float throwStartTime;
    private bool isThrowing = false;

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

    private void OnMouseDown()
    {
        Debug.Log("click");

        if (isHeld)
        {
            // start throwing
            throwStartTime = Time.time;
            isThrowing = true;
        }
        else
        {
            PickUp();
        }
    }

    private void OnMouseUp()
    {
        // throw inly if object is held and throwing has started
        if(isHeld && isThrowing)
        {
            Throw();
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
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void Drop()
    {
        isHeld = false;
        rigidbody.useGravity = true;
        rigidbody.constraints = RigidbodyConstraints.None;
        transform.SetParent(null);
    }

    private void Throw()
    {
        Drop();

        float throwTime = Time.time - throwStartTime;
        float forceMultiplier = Mathf.Min(throwTime * throwForce, maxThrowForce);
        Debug.Log(forceMultiplier);
        rigidbody.AddForce(mainCamera.transform.forward*forceMultiplier, ForceMode.Impulse);

        isThrowing = false;
    }

    
}
