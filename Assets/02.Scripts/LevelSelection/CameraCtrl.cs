using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public Vector3 offset;
    public float followSpeed = 0.15f;

    public GameObject player;


    void FixedUpdate()
    {
        Vector3 camera_pos = player.transform.position + offset;
        Vector3 lerp_pos = Vector3.Lerp(transform.position, camera_pos, followSpeed);
        transform.position = lerp_pos;
        transform.LookAt(player.transform);
    }
}