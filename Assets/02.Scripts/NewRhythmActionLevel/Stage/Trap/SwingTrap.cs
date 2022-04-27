using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingTrap : MonoBehaviour
{
    [SerializeField] float slowNum;
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag ==  "Player")
        {           
            HealthSystem.Instance.TakeDamage(15f);
            PlayerController playerC = collision.gameObject.GetComponent<PlayerController>();
            //슬로우
            StartCoroutine(PlayerSlow(slowNum, playerC));
        }
    }

    IEnumerator PlayerSlow(float slowNum, PlayerController playerC)
    {           
        float speed = playerC.moveSpeed;
        playerC.MoveSpeedSlow(slowNum);
        //인펙트 실행
        yield return new WaitForSeconds(1f);
        playerC.MoveSpeedUp(speed);
    }
}
