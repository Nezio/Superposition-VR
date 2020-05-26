using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDeleter : MonoBehaviour
{
    public GameObject objectToDelete;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Destroy(objectToDelete);
        }
    }
}
