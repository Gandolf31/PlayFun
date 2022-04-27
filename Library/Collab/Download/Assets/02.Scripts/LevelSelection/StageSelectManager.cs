using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectManager : MonoBehaviour
{
    GameManager gameManager;
    public static StageSelectManager stageManager;
    public GameObject level01, level02, level03, level04;
    public int levelPassed = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.gm;
        level02.gameObject.SetActive(false);
        level03.gameObject.SetActive(false);
        level04.gameObject.SetActive(false);
    }

    void Update()
    {
        switch (gameManager.levelPassed)
        {
            case 1:
                level02.gameObject.SetActive(true);
                break;
            case 2:
                level02.gameObject.SetActive(true);
                level03.gameObject.SetActive(true);
                break;
            case 3:
                level02.gameObject.SetActive(true);
                level03.gameObject.SetActive(true);
                level04.gameObject.SetActive(true);
                break;
        }
    }
    /*
    public void clear(GameObject LV)
    {
        if (LV.Equals(level01))
            levelPassed = 1; // 레벨 1 스테이지로 진입 >> 클리어 시 levelPassed = 1로 변경해야함.
        if (LV.Equals(level02))
            levelPassed = 2; // 지금은 레벨 클릭 시 바로 그 스테이지가 클리어되도록 했음
        if (LV.Equals(level03))
            levelPassed = 3;
    }
    */
}
