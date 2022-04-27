using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayStart : MonoBehaviour
{
    bool isStart = false;
    public GameObject InvisibleNote;

    // Start is called before the first frame update
    void Start()
    {
        isStart = true;
        InvisibleNote.gameObject.SetActive(false);
        if(isStart == true)
        {
            StartCoroutine("GameStart");
        }
    }

    // Update is called once per frame
    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(4f);
        isStart = false;
        InvisibleNote.gameObject.SetActive(true);
    }
}
