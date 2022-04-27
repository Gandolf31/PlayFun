using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSync : MonoBehaviour
{
    AudioSource playTik;
    public AudioClip tik;

    MoveNote moveNote;

    float musicBPM = 120f;
    float stdBPM = 60f;
    int musicTempo = 4;
    int stdTempo = 4;

    float tikTime = 1;
    float nextTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        playTik = GetComponent<AudioSource>();
        moveNote = GameObject.Find("Note").GetComponent<MoveNote>();
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (stdBPM / musicBPM) * (musicTempo / stdTempo);

        nextTime += Time.deltaTime;

        if(nextTime > tikTime)
        {
            StartCoroutine(PlayTik(tikTime));
            nextTime = 0;
        }
    }

    IEnumerator PlayTik(float tikTime)
    {
        
        Debug.Log(nextTime);    // 시간오차
        moveNote.RotateNote();
        playTik.PlayOneShot(tik);   // 재생
        yield return new WaitForSeconds(tikTime);
    }
}
