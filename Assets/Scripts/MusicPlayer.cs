using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    private void Start()
    {
        // play audio
        if (!AudioManager.instance.IsPlaying("Music"))
        {
            AudioManager.instance.Play("Music");
        }
    }
}
