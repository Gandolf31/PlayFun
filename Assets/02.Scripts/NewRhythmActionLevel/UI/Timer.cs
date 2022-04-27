using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeValue;

    public GameObject goal;

    public Text timerText;
    

    private void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
            GoalManager goalmanager = goal.GetComponent<GoalManager>();
            goalmanager.Fail();
          
            
        }
        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
     if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
            
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
       
    }
}
