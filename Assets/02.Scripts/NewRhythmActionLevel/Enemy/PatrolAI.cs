using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAI : MonoBehaviour
{

    public NavMeshAgent nav; //인스펙터에서 추가

    public GameObject[] targets; //인스펙터에서 추가
    public Transform Player;

    private int point = 0;
    private bool isPlayer;
    void Start()
    {
        next();
    }

    // Update is called once per frame

    void Update()
    {
        float dist = Vector3.Distance(Player.position, transform.position);

        if (!isPlayer && !nav.pathPending && nav.remainingDistance < 2f) next();

        if (dist < 5)                                  //거리의 차이가 setdist 이하일때
        {
            isPlayer = true;
            //run
            nav.destination = Player.position;      //enemy를 player의 위치로 이동
        }
        else
            isPlayer = false;
    }

    void FixedUpdate()
    {
    }

    void next()
    {
        if (targets.Length == 0) return;

        nav.destination = targets[point].transform.position;
        point = (point + 1) % targets.Length;
    }
}