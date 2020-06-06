using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerController player;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player" && other.tag != "QuantumLocation")
        {
            player.velocity = Vector3.zero;
        }
    }
    
}
