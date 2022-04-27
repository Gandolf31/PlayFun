using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GoalManager : MonoBehaviour
{
    // 승리 또는 실패를 여기서 처리함
    [SerializeField] GameObject healthSystem;
    [SerializeField] GameObject badUI;
    [SerializeField] GameObject goodUI;
    [SerializeField] GameObject Player;

    PlayerController playerC; 
    private void Start()
    {
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
            goodUI.GetComponent<Text>().enabled = true;
            playerC.StopMove(false);
            //무적 필요
            //성공 애니메이션 필요    
            Invoke("GoToLevelSelect", 3f);
        }
    }

    public void Fail()
    {
        //지면 나오는 UI와 플레이어 정지
        badUI.GetComponent<Text>().enabled = true;
        playerC.StopMove(false);
        //죽는 애니메이션 필요 
    }

    void GoToLevelSelect()
    {
        SceneManager.LoadSceneAsync("LevelSelect");
    }
}
