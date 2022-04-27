using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapDemo : MonoBehaviour {

    //This script goes on the SpikeTrap prefab;
    Animator spikeTrapAnim; //Animator for the SpikeTrap;
    BoxCollider trapArea;
    [SerializeField] float openTime;
    [SerializeField] float closeTime;
    // Use this for initialization
    void Awake()
    {
        //get the Animator component from the trap;
        spikeTrapAnim = GetComponent<Animator>();
        //
        trapArea = GetComponent<BoxCollider>();
        //start opening and closing the trap for demo purposes;
        StartCoroutine(OpenCloseTrap());
    }


    IEnumerator OpenCloseTrap()
    {
        //wait N seconds;
        yield return new WaitForSeconds(closeTime);
        //play open animation;
        spikeTrapAnim.SetTrigger("open");
        trapArea.enabled = true;
        //wait N seconds;
        yield return new WaitForSeconds(openTime);
        //play close animation;
        spikeTrapAnim.SetTrigger("close");
        trapArea.enabled = false;
        //Do it again;
        StartCoroutine(OpenCloseTrap());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Player")
        {
            HealthSystem.Instance.TakeDamage(5f);
        }
    }
}