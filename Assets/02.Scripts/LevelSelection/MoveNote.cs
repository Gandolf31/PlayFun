using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNote : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RotateNote()
    {
        transform.Rotate(Vector3.back * 45);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
