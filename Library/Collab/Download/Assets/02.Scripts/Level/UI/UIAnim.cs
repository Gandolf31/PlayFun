using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIAnim : MonoBehaviour
{   
    
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    private SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void level1On()
    {
        Animator animator = button1.GetComponent<Animator>();
        animator.SetBool("isMove", true);
    }

    public void StageOpen()
    {
        SceneManager.LoadScene(2);
    }

    public void MenuFade()
    {
        Animator animator = button1.GetComponent<Animator>();
        animator.SetBool("isMove", false);
       
    }
}
