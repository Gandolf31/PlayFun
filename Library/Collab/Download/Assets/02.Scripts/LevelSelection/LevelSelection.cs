using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngineInternal;

public class LevelSelection : MonoBehaviour
{
    StagePopUp stPopup;

    public bool isInside;

    public GameObject PopUp;
    public GameObject player;

    public void Start()
    {
        //this.gameObject.layer = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        stPopup = PopUp.GetComponent<StagePopUp>();
        PopUp.SetActive(false);
        stPopup.defaultTR = player.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isInside = true;
            PopUp.SetActive(true);
            stPopup.checkAnim(1);
            stPopup.defaultTR = player.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isInside = false;
            Debug.Log("충돌 끝");
            stPopup.checkAnim(2);
            stPopup.defaultTR = player.transform.position;
        }
    }
}