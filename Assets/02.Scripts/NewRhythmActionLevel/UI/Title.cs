using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Title : MonoBehaviour
{
    public GameObject SettingMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        SceneManager.LoadScene(1);
    }

    public void Setting()
    {
        SettingMenu.SetActive(true);
    }
}
