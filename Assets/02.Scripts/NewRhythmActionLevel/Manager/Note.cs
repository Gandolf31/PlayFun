using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float noteSpeed = 400;

    bool musicDelay = false;

    UnityEngine.UI.Image noteImage;

    private void Start()
    {
        noteImage = GetComponent<UnityEngine.UI.Image>();
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void HideNote()
    {
        noteImage.enabled = false;
    }

    public void OnNoteImage()
    {
        noteImage.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.right * noteSpeed * Time.deltaTime;
    }
}
