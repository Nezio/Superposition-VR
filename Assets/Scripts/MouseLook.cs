using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        player.transform.Rotate(Vector3.up * mouseX);

        Debug.Log(mouseX);

    }
}
