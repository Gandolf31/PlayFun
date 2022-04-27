/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    GameObject BackgroundMusic;
    AudioSource backmusic;

    void Awake()
    {
        BackgroundMusic = GameObject.Find("BackgroundMusic");
        backmusic = BackgroundMusic.GetComponent<AudioSource>(); //배경음악 저장해둠
        if (!backmusic.isPlaying) return; //배경음악이 재생되고 있다면 패스
        else
        {
            backmusic.Play();
            DontDestroyOnLoad(gameObject);
        }
    }
}*/
