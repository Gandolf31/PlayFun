using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseEnemy : MonoBehaviour
{
    NavMeshAgent navAgent;
    public Transform Player;
    public float setDist;

    //임시 hp연결
    public GameObject Healthbar;
    HealthSystem HPsys;
    // Start is called before the first frame update
    void Start()
    {
        HPsys = Healthbar.GetComponent<HealthSystem>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(Player.position, transform.position);
        if (dist < 3)
        {
           //walk
        }
        else if (dist < setDist)                                  //거리의 차이가 setdist 이하일때
        {
            //run
            navAgent.destination = Player.position;      //enemy를 player의 위치로 이동
        }
        else
        {
            //idle
            navAgent.velocity = Vector3.zero;            //거리가 길 때  
        }
    }
    void OnTriggerStay(Collider other)
    {
        //공격에
        if (other.tag == "Player")
        {
            //GameOver = true;
            Debug.Log("Damaged");
            HPsys.TakeDamage(10);
            navAgent.velocity = Vector3.zero;
        }
    }

    public void OnDamage()
    {
        Destroy(this.gameObject);
    }
}
