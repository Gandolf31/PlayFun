using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UISelect : MonoBehaviour
{
    public GameObject Stage1;
    public GameObject Stage2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StageOne()
    {   
        Animator animator = Stage1.GetComponent<Animator>();
        animator.SetBool("isOpen", true);

    }

    public void StageOneClose()
    {
        Animator animator = Stage1.GetComponent<Animator>();
        animator.SetBool("isOpen", false);
    }

    public void StageSecondClose()
    {
        Animator animator = Stage2.GetComponent<Animator>();
        animator.SetBool("isOpen", false);
    }

    public void StageTwo()
    {
        Animator animator = Stage2.GetComponent<Animator>();
        animator.SetBool("isOpen", true);
    }

    public void FirstStage()
    {
        SceneManager.LoadScene(2);

    }

    public void SecondStage()
    {
        SceneManager.LoadScene(3);
    }
}
