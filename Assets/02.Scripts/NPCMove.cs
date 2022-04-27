using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : MonoBehaviour
{
    public Transform[] waypoints;
    public int speed;

    private int waypointIndex;
    private float dist;
    Animator animator;


     void Start()
    {
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if(dist < 1f)
        {
            IncreaseIndex();
            
        }
        animator.SetBool("isWalking", true);
        
        Patrol();
    }

    void Patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
    }

    void IncreaseIndex()
    {
        waypointIndex++;
        if(waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;

        }
        transform.LookAt(waypoints[waypointIndex].position);
    }
}
