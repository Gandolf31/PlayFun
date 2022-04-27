using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameMenuC : MonoBehaviour
{
    List<Resolution> resolutions = new List<Resolution>();
    public GameObject PauseB;
    public static bool GameIsPaused = false;
    public GameObject PauseMenu;
    public GameObject Title;
    public GameObject Setting;
    public GameObject SettingB;
    public GameObject Screen;
    public GameObject ResumeB; 
   


 

   

    public void isGamePaused()
    {
        Time.timeScale = 0;
        GameIsPaused = true;
        PauseMenu.SetActive(true);
      
         }

    

    public void fadePauseMenu()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }
    public void SettingMenu()
    {
        Setting.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    public void fadeButton()
    {
        PauseB.SetActive(false);
        
    }

    public void appearButton()
    {
        PauseB.SetActive(true);
    }
    public void appearSettingButton()
    {
        SettingB.SetActive(true);
    }

    public void SettingOn()
    {
        Setting.SetActive(true);
        SettingB.SetActive(false);
        Time.timeScale = 0;
        GameIsPaused = true;
     

    }
    public void SettingOff()
    {
        Setting.SetActive(false);
        SettingB.SetActive(true);
        Time.timeScale = 1;
        GameIsPaused = false;


    }

    public void CheckOn()
    {
        Title.SetActive(true);
    }
    public void CheckOff()
    {
        Title.SetActive(false);
    }

    public void GoTitle()
    {

        SceneManager.LoadScene("GameStart");
        GameIsPaused = false;
        Time.timeScale = 1;
    }

    public void GoLevelSelect()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(6);
      
    }

    public void ScreenOn()
    {
        Screen.SetActive(true);
    }
    public void ScreenOff()
    {
        Screen.SetActive(false);
        

    }
   public void Resume()
    {
        ResumeB.SetActive(false);
       
    }
}
