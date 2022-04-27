using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{   
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            //collider.gameObject.GetComponent<EnemyBase>().OnDamage();
        }
    }
}
