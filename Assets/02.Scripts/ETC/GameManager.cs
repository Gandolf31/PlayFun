using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public int presentLevel = 0; //현재 또는 최근 갔다온 레벨
    public int levelPassed = 0; // 클리어 한 레벨 : 클리어 후 오픈될 레벨
    public Vector3 playerPos;
    private void Awake()
    {
        if (GameManager.gm == null)
        {
            GameManager.gm = this;
        }
        var a = FindObjectsOfType<GameManager>();
        if (a.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
