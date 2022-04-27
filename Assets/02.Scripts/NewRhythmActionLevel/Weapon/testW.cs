using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testW : MonoBehaviour
{
    Rigidbody a;
    // Start is called before the first frame update
    void Start()
    {
        a = this.gameObject.GetComponent<Rigidbody>();
        a.velocity = new Vector3(-1,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
