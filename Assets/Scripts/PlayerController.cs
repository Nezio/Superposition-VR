using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float movementSpeed = 2f;
    public float gravity = -9.81f;

    public Transform groundCheck;

    [HideInInspector]
    public Vector3 velocity;

    private Camera mainCamera;
    

    void Start()
    {
        mainCamera = Camera.main;

        mainCamera.transform.rotation = Quaternion.identity;
    }

    private float maxX = 0;
    private float maxY = 0;
    private float maxZ = 0;

    void Update()
    {
        // look down to move
        if(mainCamera.transform.eulerAngles.x >= 45f && mainCamera.transform.eulerAngles.x < 77f)
        {
            MoveForward();
        }

        // move on user input (W, RMB or back button on Android (this is to enable RMB on Android when mouse is connected))
        if (Input.GetKey(Tools.GetKeycode("W")) || Input.GetMouseButton(1) || Input.GetKey(KeyCode.Escape))
        { 
            MoveForward();
        }

        // falling
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void MoveForward()
    {
        Vector3 move = new Vector3(mainCamera.transform.forward.x, 0, mainCamera.transform.forward.z).normalized * Time.deltaTime * movementSpeed;
        controller.Move(move);

        // play audio if no other footstep sound is playing
        bool footstepSoundPlaying = false;
        int numberOfFootstepSounds = 5;
        for (int i = 1; i < numberOfFootstepSounds + 1; i++)
        {
            if (AudioManager.instance.IsPlaying("Footstep" + i))
            {
                footstepSoundPlaying = true;
            }
        }
        if (!footstepSoundPlaying)
        {
            AudioManager.instance.PlayOneShot("Footstep" + Random.Range(1, numberOfFootstepSounds + 1));
        }
        

    }

}
