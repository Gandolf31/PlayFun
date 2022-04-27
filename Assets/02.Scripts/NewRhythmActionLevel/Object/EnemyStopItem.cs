using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStopItem : MonoBehaviour
{
    public GameObject Enemy;

    EnemyBase enemyBase;
    Animator StopEffect;
    MeshRenderer meshRenderer;
    float Speed = 100f;
    bool isGet = false;

    void Start()
    {
        enemyBase = Enemy.GetComponent<EnemyBase>();
        StopEffect = gameObject.GetComponent<Animator>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Speed * Time.deltaTime));   
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //아이템 효과
            //적 이동 스크립트 참조해서 이거 먹으면 전원 제자리에 n초 동안 고정한다.
            StartCoroutine("StopEnemy");
            StopEffect.SetBool("isGet", true);
        }
    }

    IEnumerator StopEnemy()
    {
        meshRenderer.enabled = false;

        enemyBase.isStop = true;
        enemyBase.nav.enabled = false;

        yield return null;

        enemyBase.nav.enabled = true;

        Invoke("IsStop", 4f);
    }

    void IsStop()
    {
        enemyBase.isStop = false;
        StopCoroutine(StopEnemy());
        Destroy(gameObject);
    }
}