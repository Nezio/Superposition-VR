using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 2f;

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(Tools.GetKeycode("W")))
        {
            transform.position +=  new Vector3(mainCamera.transform.forward.x, transform.forward.y, mainCamera.transform.forward.z) * Time.deltaTime * movementSpeed;
        }

    }
}
