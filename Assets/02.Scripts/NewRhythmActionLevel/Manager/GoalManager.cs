using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GoalManager : MonoBehaviour
{
    // 승리 또는 실패를 여기서 처리함
    [SerializeField] GameObject badUI;
    [SerializeField] GameObject goodUI;
    [SerializeField] GameObject Player;

    GameManager gameManager;

    PlayerController playerC; 
    private void Start()
    {
        gameManager = GameManager.gm;
        playerC = Player.GetComponent<PlayerController>();
    }
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)    
    {
        if (other.tag == "Player")
        {
            //SceneManager.LoadSceneAsync("LevelSelect");
            NoteManager.Instance.bpm = 0;
            goodUI.GetComponent<Text>().enabled = true;
            playerC.StopMove(false);
            //무적 필요
            //성공 애니메이션 필요
            Invoke("GoToLevelSelect", 1f);
            switch (gameManager.presentLevel)
            {
                case 1:
                    gameManager.levelPassed = 1;
                    break;
                case 2:
                    gameManager.levelPassed = 2;
                    break;
                case 3:
                    gameManager.levelPassed = 3;
                    break;
                default:
                    break;
            }            
            
        }
    }

    public void Fail()
    {
        //지면 나오는 UI와 플레이어 정지
        badUI.GetComponent<Text>().enabled = true;
        playerC.StopMove(false);
        Animator animator = Player.GetComponent<Animator>();
        animator.SetBool("isDie", true);
        if (Input.GetKey(KeyCode.R))
            {
                if (SceneManager.GetActiveScene().name == "RhythmActionLevel1")
                {
                    SceneManager.LoadScene("RhythmActionLevel1");
                    Time.timeScale = 1;
                }
                else if (SceneManager.GetActiveScene().name == "RhythmActionLevel2")
                {
                    SceneManager.LoadScene("RhythmActionLevel2");
                    Time.timeScale = 1;

                }
                else if (SceneManager.GetActiveScene().name == "RhythmActionLevel3")
                {
                    SceneManager.LoadScene("RhythmActionLevel3");
                    Time.timeScale = 1;
                }
            }
        //죽는 애니메이션 필요 
    }

    void GoToLevelSelect()
    {
        Loadibng.LoadScene("LevelSelect");
    }
}
