using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    [SerializeField]
    GameObject map;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject enemyManager;
    [SerializeField]
    GameObject goal;

    // 플레이어가 레벨 내에서 움직일 수 있는 회수
    [SerializeField]
    private int limitPlayerTurn;


    // 플레이어의 처음 위치
    public Vector3 start;


    //플레이어가 움직인 위치값 큐로 저장 / 플레이를 누르게 되면 사용되는 변수 
    Queue<Vector3> playerTurn = new Queue<Vector3>();


    //플레이어가 움직인 위치값 큐로 저장 / 뒤로가기 버튼을 누르게 되면 사용되는 변수
    Stack<Vector3> backTurn = new Stack<Vector3>();

    Player py;
    MapManager m;
    EnemyManager en;
    Tile[,] mapTiles;
    int map_size_x, map_size_z;

    private void Awake()
    {
        if (LevelManager.levelManager == null)
        {
            LevelManager.levelManager = this;
        }

    }
    private void Start()
    {
        py = player.GetComponent<Player>();
        m = map.GetComponent<MapManager>();
        en = enemyManager.GetComponent<EnemyManager>();
        py.MovePlayer(start);
        m.PlayerMoveTileMarking();
    }

    public void PlayerTurnAdd(Vector3 pos)
    {
        if (playerTurn.Count < limitPlayerTurn)
        {
            //플레어 턴 저장
            playerTurn.Enqueue(pos);
            backTurn.Push(pos);
            Debug.Log(backTurn.Count);
            //플레이어 움직임 
            py.MovePlayer(pos);

            //표시되었던 것을 다 없에고 다시 플레이어 위치값을 기준으로 표시
            m.CleanTileMarking();
            m.PlayerMoveTileMarking();
        }
    }

    public void Play_Turn() //지금까지 저장된 모든 턴 실행
    {
        m.CleanTileMarking();
        //모든 적 콜라이더 키기
        en.EnemysColliderOn();
        py.MovePlayer(start);
        StartCoroutine("Turn");
    }

    IEnumerator Turn()
    {
        int turnNum = playerTurn.Count;
        for (int i = 0; i < turnNum; i++)
        {
            //플레이어턴 한번 실행
            //attack layer (11번)으로 플레이어 layer 바꾸기
            yield return new WaitForSeconds(0.3f);
            py.SetLayer(11);
            py.MovePlayer(playerTurn.Dequeue());
            yield return new WaitForSeconds(0.3f);
            py.SetLayer(13);


            //마지막 턴에서는 적의 움직임 없이 
            if (i < turnNum - 1)
            {
                en.EnemysMove();
                yield return new WaitForSeconds(0.5f);
            }
        }

        // 골의 콜라이더 킴
        goal.GetComponent<SphereCollider>().enabled = true;

    }

    public void TurnBack()
    {
        // 모든 마크 지운다
        m.CleanTileMarking();


        //턴이 0 경우
        if (playerTurn.Count == 0)
        {
            Debug.Log("사용한 턴이 없습니다.");
        }
        //턴이 1 경우
        else if (playerTurn.Count == 1)
        {
            backTurn.Pop();
            playerTurn.Dequeue();
            py.MovePlayer(start);
        }
        //턴이 limit 보다 작을 경우 
        else if (playerTurn.Count <= limitPlayerTurn)
        {
            // 현재 턴수 저장
            int numberOfTurn = playerTurn.Count;
            //첫번째로 저장한 것을 삭제함
            backTurn.Pop();
            //두번째로 저장된 것 pos에 저장
            Vector3 pos = backTurn.Pop();
            //플레이어를 pos로 이동
            py.MovePlayer(pos);
            //다시 pos backturn에 저장
            backTurn.Push(pos);

            //playerTurn 데이터 삭제
            for (int i = 0; i < numberOfTurn; i++)
            {
                playerTurn.Dequeue();
                // 0 나오는지 확인
            }

            //playerTurn 뒤로 이동한 데이터로 변경

            Queue<Vector3> temporary = new Queue<Vector3>();
            Stack<Vector3> reverse = new Stack<Vector3>();
            //backturn크기 저장
            int stackNum = backTurn.Count;

            for (int a = 0; a < stackNum; a++)
            {
                reverse.Push(backTurn.Pop());
            }
            //backturn 모든 데이터를 playerTurn에 저장
            for (int i = 0; i < stackNum; i++)
            {
                Vector3 turn = reverse.Pop();
                Debug.Log(turn);
                playerTurn.Enqueue(turn);
                temporary.Enqueue(turn);
            }
            //temporary 모든 데이터를 backTurn에 저장
            for (int j = 0; j < stackNum; j++)
            {
                backTurn.Push(temporary.Dequeue());
            }
        }


        // 플레이어 위치에 맞게 마킹
        m.PlayerMoveTileMarking();

    }

    public void IsPlayerWin()
    {
        Debug.Log("Win");
    }
}
