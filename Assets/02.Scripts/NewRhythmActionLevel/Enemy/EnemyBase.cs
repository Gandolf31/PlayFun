using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    [SerializeField]
    ParticleSystem deathEffect;

    public enum Type { A, B, C };
    public Type             enemyType;
    public NavMeshAgent     nav;
    public BoxCollider      meleeArea;
    public GameObject[]     patrolTargets;
    public GameObject       bullet;
    public Transform        target;
    
    public int              maxHealth;
    public int              curHealth;
    public bool             isChase;
    public bool             isAttack;
    public bool             isStop;
    private int             point = 0;
    private bool            isPlayer;
   

    Rigidbody rigid;
    BoxCollider boxCollider;
    Animator anim;


    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        Invoke("ChaseStart", 2);
    }

    void FreezeVelocity()
    {
        if (isChase)
        {
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
        }
    }

    void Targeting()
    {
        float targetRadius = 0;
        float targetRange = 0;

        switch (enemyType)
        {
            case Type.A:
                targetRadius =1.6f;
                targetRange = 2.4f;   // 수치가 낮을수록 가까이에서 공격(애니메이션)
                break;
            case Type.B:
                targetRadius = 1f;  // 폭
                targetRange = 1f;   // 직선상 거리   >>   공격을 시작하는 거리
                break;
            case Type.C:
                targetRadius = 0.1f;  // 폭
                targetRange = 0.1f;
                break;
        }

        RaycastHit[] rayHits =
            Physics.SphereCastAll(transform.position,
                targetRadius, transform.forward, targetRange,
                LayerMask.GetMask("Player"));
        if(rayHits.Length > 0 && !isAttack)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isChase = false;
        isAttack = true;
        anim.SetBool("isAttack", true);
        switch (enemyType)
        {
            case Type.A:
                yield return new WaitForSeconds(0.1f); // 선딜
                meleeArea.enabled = true;
                
                yield return new WaitForSeconds(1.2f);    // 공격 중 >> 애니메이션이랑 속도 맞춰줘야함
                meleeArea.enabled = false;

                yield return new WaitForSeconds(0.4f);
                break;
            case Type.B:
                 yield return new WaitForSeconds(0.1f);
                rigid.AddForce(transform.forward * 10, ForceMode.Impulse);
                yield return new WaitForSeconds(1f);
                rigid.velocity = Vector3.zero;


                yield return new WaitForSeconds(1.5f);
                break;
            case Type.C:
                yield return new WaitForSeconds(0.1f);
                GameObject instantBullet = Instantiate(bullet, transform.position, transform.rotation);
                Rigidbody rigidBullet = instantBullet.GetComponent<Rigidbody>();
                rigidBullet.velocity = transform.forward * 10;
                yield return new WaitForSeconds(0.2f);
                anim.SetBool("isAttack", false);
                yield return new WaitForSeconds(2f);
                break;
        }
        isChase = true;
        isAttack = false;
        anim.SetBool("isAttack", false);
    }


    void ChaseStart()
    {
        isChase = true;
        anim.SetBool("isWalk", true);
        next();
    }

    void Update()
    {
        float dist = Vector3.Distance(target.position, transform.position);
        if(!isStop)
        {
            switch (enemyType)
            {
                case Type.A:
                    if (!isPlayer && !nav.pathPending && nav.remainingDistance < 2f) ChaseStart();
                    
                    if (dist < 4)
                    {
                        isPlayer = true;
                        nav.speed = 2.6f;
                        nav.SetDestination(target.position);
                        anim.SetBool("isRun", true);
                        nav.isStopped = !isChase;
                    }
                    else
                    {
                        isPlayer = false;
                        anim.SetBool("isRun", false);
                    }
                    break;
                case Type.B:
                    if (!isPlayer && !nav.pathPending && nav.remainingDistance < 2f) ChaseStart();

                    if (dist < 8)                                  //거리의 차이가 5 이하일때
                    {
                        isPlayer = true;
                        nav.SetDestination(target.position);
                        anim.SetBool("isRun", true);
                        nav.isStopped = !isChase;
                    }
                    break;
                case Type.C:
                    if(!isAttack)
                    {
                        StartCoroutine(Attack());
                    }
                    /*
                    if (dist <= 7)
                    {                       
                        transform.LookAt(target);
                        Targeting();
                    }
                    */
                    break;
            }
        }
        if(curHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        Targeting();
        FreezeVelocity(); 
    }
    void next()
    {
        if (patrolTargets.Length == 0) return;

        nav.destination = patrolTargets[point].transform.position;
        point = (point + 1) % patrolTargets.Length;
    }

    public void onDamaged(int Dmg)
    {
        curHealth =- Dmg;
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Player" && enemyType == Type.B)
        {
            HealthSystem.Instance.TakeDamage(10f);
            onDamaged(100);
        }
        if(coll.gameObject.tag == "Weapon")
        {
            onDamaged(50);
        }
    }
}
