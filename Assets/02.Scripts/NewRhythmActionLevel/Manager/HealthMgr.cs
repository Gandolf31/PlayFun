using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMgr : MonoBehaviour
{
    HealthSystem HPSys;   
    [SerializeField] GameObject player;
    [SerializeField] GameObject healthSystem;
    // Start is called before the first frame update
    void Start()
    {        
        HPSys = healthSystem.gameObject.GetComponent<HealthSystem>();
    }

    public void HealedByItem(float Damage)
    {
        HPSys.HealDamage(Damage);
    }

    public void DamagedByEmeny(float Damage)
    {
       // >> player state로 옮겨서 충돌 시 무적으로 변경
        StartCoroutine("OffDamaged", Damage);
    }

    IEnumerator OffDamaged(float Damage)
    {
        player.gameObject.layer = 11;
        HPSys.TakeDamage(Damage);
        yield return new WaitForSeconds(2f);
        player.gameObject.layer = 9;
    }
}
