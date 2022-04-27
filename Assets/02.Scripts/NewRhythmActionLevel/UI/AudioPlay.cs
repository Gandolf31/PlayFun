using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public AudioSource audioSource;
    private GameObject[] musics;
    // Start is called before the first frame update
    private void Awake()
    {
        musics = GameObject.FindGameObjectsWithTag("Music");

        if(musics.Length >= 2)
        {
            Destroy(this.gameObject);

        }
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
    }

  public void PlayMusic()
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }
    public void StopMusic()
    {
        audioSource.Stop();
    }
}
