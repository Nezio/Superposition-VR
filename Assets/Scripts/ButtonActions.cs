using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActions : MonoBehaviour
{
    public void ChangeColor()
    {
        var r = (float)Random.Range(0, 255) / 255;
        var g = (float)Random.Range(0, 255) / 255;
        var b = (float)Random.Range(0, 255) / 255;

        gameObject.GetComponent<Renderer>().material.color = new Color(r, g, b);
    }

    public void PrintMessage()
    {
        Debug.Log("Message");
    }
}
