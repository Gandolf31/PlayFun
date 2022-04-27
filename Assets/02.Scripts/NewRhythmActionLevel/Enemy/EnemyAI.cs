using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent navAgent;
    public Transform Player;
    public float setDist;
    public GameObject Vattack;//?????뭐임??
    public GameObject attackArea;
    private bool canattack=false;
    //임시 hp연결 >> hp시스템이나 피격 매니저를 만들어서 연결해줄것임.
    public GameObject Healthbar; // 피격을 했다는 정보를 매니저에 전달하는 것으로 변경
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
        if (canattack == true)
        {
            Debug.Log(1);
            StartCoroutine(attack()); // 따로 스크립트를 만들어서 스타트에 invoke를 줄수도 있음. 정 안되면 코루틴 사용
        }
    }
    // 따로 충돌 범위를 만들고, 그 범위 내에 들어왔을 경우 (Trigger) 피격 or 타격
    /*
    private void OnCollisionEnter(Collision collision)
    {
        attack();
        //atk 레이어를 가진 오브젝트에 충돌할 경우 데미지로 변경.
        //invoke를 이용해서 triggerstay상태에서 무한 반복을 방지. bpm매니저같은 곳에서 박자를 받아와서 참일 경우만 공격하는 방식을 사용 가능
        if (collision.collider.tag == "Player")
        {
            //GameOver = true;
            Debug.Log("Damaged");
            HPsys.TakeDamage(10);
            navAgent.velocity = Vector3.zero;
        }
    }
    */
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //GameOver = true;
            Debug.Log("Damaged");
            navAgent.velocity = Vector3.zero;
            canattack = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            navAgent.velocity = Vector3.zero;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            canattack = false;
    }

    public void pDmg()
    {
        HPsys.TakeDamage(10);
    }

    public void OnDamage()
    {
        Destroy(this.gameObject);
    }

    IEnumerator attack()
    {
        attackArea.SetActive(true);
        //어떻게 공격할꺼야
        yield return new WaitForSeconds(0.2f);
        attackArea.SetActive(false);
    }
}
