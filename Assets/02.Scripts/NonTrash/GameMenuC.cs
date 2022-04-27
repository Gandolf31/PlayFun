/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMenuC : MonoBehaviour
{
    public GameObject PauseB;
    public static bool GameIsPaused = false;
    public GameObject PauseMenu;
    public GameObject Title;
    public GameObject Inventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    public void fadeButton()
    {
        PauseB.SetActive(false);
        
    }

    public void appearButton()
    {
        PauseB.SetActive(true);
    }

    public void InventoryOn()
    {   if (Inventory.activeSelf == false)
            Inventory.SetActive(true);
        else
            Inventory.SetActive(false);
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

        SceneManager.LoadScene(5);
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
}
*/