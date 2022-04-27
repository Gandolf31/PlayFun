using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tile : MonoBehaviour
{
    public Vector3 pos;
    public bool isMarking; // 움직일 수 있는 곳
    public bool isWall = false;
    [SerializeField]
    GameObject mark;

    private void Awake()
    {
        isMarking = false;
        pos = gameObject.transform.position;
    }
    private void Start()
    {
        mark.SetActive(false);
    }
    public void Marking(bool isMark)
    {
        mark.SetActive(isMark);
    }
}