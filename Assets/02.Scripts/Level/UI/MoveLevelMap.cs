using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveLevelMap : MonoBehaviour
{

    public void Click()
    {
        SceneManager.LoadSceneAsync("LevelMap");
    } 
}
