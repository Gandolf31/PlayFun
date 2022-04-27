using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterFrame : MonoBehaviour
{
    AudioSource MyAudio;
    bool MusicStart = false;

    private void Start()
    {
        MyAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!MusicStart) 
        {
            if (other.CompareTag("Note"))
            {
                MyAudio.Play();
                MusicStart = true;
            }
        }
    }
}
