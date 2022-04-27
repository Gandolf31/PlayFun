using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StagePopUp : MonoBehaviour
{
    LevelSelection levelSelection;
    GameManager gameManager;

    [SerializeField] GameObject LookTarget;
    [SerializeField] GameObject myStage;
    public AnimationCurve aniCurve1;
    public AnimationCurve aniCurve2;
    public float timeCount1 = 0;
    public float timeCount2 = 0;
    public float aniSpeedMul = 1f;

    private bool isAnim;
    public int levelNum;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.gm;
        levelSelection = myStage.GetComponent<LevelSelection>();
    }

    public void checkAnim(int n)
    {
        if (n == 1)
            isAnim = true;
        else if(n == 2)
            isAnim = false;
    }

    // Update is called once per frame
    void Update()
    {
        //쳐다보고 확대/축소하는 애니메이션
        transform.LookAt(LookTarget.transform.position);
        if (isAnim.Equals(true))
        {
            timeCount1 += Time.deltaTime;
            float myScale = aniCurve1.Evaluate(timeCount1 * aniSpeedMul);
            transform.localScale = new Vector3(myScale/16, myScale/16, 0.05f);
            timeCount2 = 0;
        }
        if (isAnim.Equals(false))
        {
            timeCount2 += Time.deltaTime;
            float myScale = aniCurve2.Evaluate(timeCount2 * aniSpeedMul);
            transform.localScale = new Vector3(myScale/16, myScale/16, 0.05f);
            timeCount1 = 0;
        }

        if(Input.GetKeyDown(KeyCode.Return)) // 엔터
        {
            gameManager.presentLevel = levelNum; //현재 들어가는 레벨 번호 게임매니저에 저장
            //SceneManager.LoadSceneAsync("RhythmActionLevel" + levelNum);
            Loadibng.LoadScene("RhythmActionLevel" + levelNum);
        }
    }

    public bool CheckInside()
    {
        return levelSelection.isInside;
    }
}