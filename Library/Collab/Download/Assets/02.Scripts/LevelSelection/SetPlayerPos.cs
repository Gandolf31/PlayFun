using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPos : MonoBehaviour
{
    StagePopUp SPopup;
    public GameObject StPopup;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        SPopup = StPopup.GetComponent<StagePopUp>();
        Player = GameObject.FindGameObjectWithTag("Player");

        Player.transform.position = SPopup.defaultTR;
    }        
}
