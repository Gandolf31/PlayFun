using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngineInternal;

public class LevelSelection : MonoBehaviour
{
    StagePopUp stPopup;

    GameManager gameManager;
    public bool isInside;

    public GameObject PopUp;
    public GameObject player;

    public void Start()
    {
        gameManager = GameManager.gm;
        player = GameObject.FindGameObjectWithTag("Player");
        stPopup = PopUp.GetComponent<StagePopUp>();
        PopUp.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isInside = true;
            PopUp.SetActive(true);
            stPopup.checkAnim(1);
            gameManager.playerPos = player.transform.position;
            Debug.Log(gameManager.playerPos);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isInside = false;
            stPopup.checkAnim(2);
        }
    }
}