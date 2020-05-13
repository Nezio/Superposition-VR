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

    private float maxX = 0;
    private float maxY = 0;
    private float maxZ = 0;

    void Update()
    {
        Debug.Log(mainCamera.transform.forward);
        // look down to move
        if(mainCamera.transform.eulerAngles.x >= 45f && mainCamera.transform.eulerAngles.x < 90f)
        {
            MoveForward();
        }

        if (Input.GetKey(Tools.GetKeycode("W")) || Input.GetMouseButton(1))
        { 
            MoveForward();
        }
    }

    private void MoveForward()
    {
        Vector3 move = new Vector3(mainCamera.transform.forward.x, 0, mainCamera.transform.forward.z).normalized * Time.deltaTime * movementSpeed;
        controller.Move(move);
    }
}
