using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.gm;
    }
    public void MovePlayer(Vector3 pos)
    {
        gameObject.transform.position = pos;
    }
    
    public void Dead()
    {
        Destroy(gameObject);
    }

    public void SetLayer(int layerNum) // 레이어를 바꿈
    {       
        gameObject.layer = layerNum;
    }

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어 layer인 경우
        if (gameObject.layer == 13)
        {
            Debug.Log(13);
            switch (other.gameObject.layer)
            {
                case 14://적일 경우 플레이어가 죽음
                    Dead();
                    break;

                case 12://goal일 경우 플레이어가 죽음
                    LevelManager.levelManager.IsPlayerWin();
                    gameManager.levelPassed++;
                    SceneManager.LoadScene("LevelSelect");
                    break;
            }
        } 
        // attack layre인 경우
        else if (gameObject.layer == 11) 
        {
            Debug.Log(11);
            switch (other.gameObject.layer)
            {                
                case 14: //적일 경우 적을 죽임
                    other.gameObject.GetComponent<Enemy>().Dead();
                    break;
            }
        }

    }
}
