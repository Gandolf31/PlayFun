using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pause;
    public GameObject choice;
    public GameObject setting;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            pause.SetActive(true);
            choice.SetActive(true);
            setting.SetActive(false);
            Time.timeScale = 0f;
            isPaused = true;
        }
        else if (isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(false);
            setting.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
    }

    public void ReStart()
    {
        if (SceneManager.GetActiveScene().name == "RhythmActionLevel1")
        {
            SceneManager.LoadScene(2);
            Time.timeScale = 1;
        }
        else if (SceneManager.GetActiveScene().name == "RhythmActionLevel2")
        {
            SceneManager.LoadScene(3);
            Time.timeScale = 1;

        }
        else if (SceneManager.GetActiveScene().name == "RhythmActionLevel3")
        {
            SceneManager.LoadScene(4);
            Time.timeScale = 1;
        }
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void SettingOn()
    {
        setting.SetActive(true);
        choice.SetActive(false);
        
    }

    public void ChoiceOn()
    {
        choice.SetActive(true);
        setting.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
