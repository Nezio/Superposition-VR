using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float movementSpeed = 2f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKey(Tools.GetKeycode("W")))
        {            
            Vector3 move = new Vector3(mainCamera.transform.forward.x, 0, mainCamera.transform.forward.z) * Time.deltaTime * movementSpeed;
            controller.Move(move);
        }

    }
}
