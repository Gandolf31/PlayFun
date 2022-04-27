using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float Speed = 20f;
    Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
       Destroy(gameObject, 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up*Speed);
    }

    void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Player")
        {
            HealthSystem.Instance.TakeDamage(10f);
            Destroy(gameObject);
        }
    }
}
