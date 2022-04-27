using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeUi : MonoBehaviour
{
    public GameObject Timer;
    public GameObject Pause;
    // Start is called before the first frame update
    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fadeTimer()
    {   
        if(Timer != null)
        {
            Animator animator = Timer.GetComponent<Animator>();
            if ( animator != null)
            {
                bool isOpen = animator.GetBool("isOpen");

                animator.SetBool("isOpen", !isOpen);
            }

        }
    }


    public void movePause()
    {
        if(Pause != null)
        {
            Animator animator = Pause.GetComponent<Animator>();
            if(animator != null)
            {
                bool isOn = animator.GetBool("isOn");
                animator.SetBool("isOn", !isOn);
                
            }
        }

        
    }
}
