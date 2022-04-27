using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Attacked");
            HealthSystem.Instance.TakeDamage(5f);
            other.gameObject.layer = 13;
            StartCoroutine("OffDamaged", other.gameObject);
        }
    }

    IEnumerator OffDamaged(GameObject player)
    {
        yield return new WaitForSeconds(4f);
        player.gameObject.layer = 9;
    }
}
