using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCam : MonoBehaviour
{
    public Camera CSCam;
    public Camera VCam;

    private void CSCamOn()
    {
        CSCam.enabled = true;
        VCam.enabled = false;
    }

    private void VCamOn()
    {
        CSCam.enabled = false;
        VCam.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        CSCamOn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if(CSCam == true)
            {
                CSCam.enabled = false;
                VCamOn();
            }
            else
            {
                CSCam.enabled = true;
                CSCamOn();
            }
        }
    }
}
