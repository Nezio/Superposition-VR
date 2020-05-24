using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMainCamera : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        transform.forward = new Vector3(mainCamera.transform.forward.x, 0, mainCamera.transform.forward.z);
    }
}
