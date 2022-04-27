using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int pattern = 0;
    BoxCollider collider;
    public int enemyNum = 0;
    private void Start()
    {
        collider = gameObject.GetComponent<BoxCollider>();
    }
    public Vector3 EnemyMove()// 매턴 움직임 좌우로 움직임
    {
        if (pattern % 3 == 0)
        {
            gameObject.transform.position += Vector3.left;
            pattern++;
            return gameObject.transform.position;
        }
        else
        {
            gameObject.transform.position += Vector3.right;
            pattern++;
            return gameObject.transform.position;
        }
    }

    public void Dead()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

    public void OnCillider() //콜라이더 키기
    {
        collider.enabled = true;
    }
}
