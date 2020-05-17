using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pickupable : MonoBehaviour
{
    public float throwForce = 5f;
    public float maxThrowForce = 10f;
    
    private GameObject player;
    private Camera mainCamera;
    private Transform hand;
    private Rigidbody rigidbody;
    private Renderer GVRPointerRenderer;
    private Color GVRReticleDefaultColor;

    private bool isHeld = false;
    private float throwStartTime;
    private bool isThrowing = false;
    private float maxPickupDistance = 5f;
    private bool isWithinReach = false;
    private bool isReticleOverObject = false;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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

        GVRPointerRenderer = GameObject.FindGameObjectWithTag("GVRPointer").GetComponent<Renderer>();
        GVRReticleDefaultColor = GVRPointerRenderer.material.color;

        EventTrigger eventTrigger = gameObject.GetComponent<EventTrigger>();
        Tools.AddEventTriggerEvent(eventTrigger, EventTriggerType.PointerDown, PointerDownEvent);
        Tools.AddEventTriggerEvent(eventTrigger, EventTriggerType.PointerUp, PointerUpEvent);
        Tools.AddEventTriggerEvent(eventTrigger, EventTriggerType.PointerEnter, PointerEnterEvent);
        Tools.AddEventTriggerEvent(eventTrigger, EventTriggerType.PointerExit, PointerExitEvent);

    }

    private void Update()
    {
        if(isReticleOverObject)
        {
            PointerOverEvent();
        }
    }


    public void PointerDownEvent()
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
            if(isWithinReach)
            {
                PickUp();
            }
        }
    
    }

    private void PointerUpEvent()
    {
        // throw only if object is held and throwing has started
        if(isHeld && isThrowing)
        {
            Throw();
        }
    }

    private void PointerEnterEvent()
    {
        isReticleOverObject = true;
    }

    private void PointerExitEvent()
    {
        isReticleOverObject = false;

        // reset visual cue
        SetVisualCueForInReach();
    }

    private void PointerOverEvent()
    {
        // by default: not reachable
        isWithinReach = false;
        SetVisualCueForNotInReach();

        // set as reachable if this object really is reachable
        Vector3 deltaPosition = transform.position - player.transform.position;
        float distance = deltaPosition.magnitude;

        if (distance <= maxPickupDistance)
        {
            isWithinReach = true;

            // set visual cue here for in reach
            SetVisualCueForInReach();
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

    private void SetVisualCueForInReach()
    {
        GVRPointerRenderer.material.color = GVRReticleDefaultColor;
    }

    private void SetVisualCueForNotInReach()
    {
        GVRPointerRenderer.material.color = Tools.Color0to1(150, 150, 150);
    }
        
    
}
