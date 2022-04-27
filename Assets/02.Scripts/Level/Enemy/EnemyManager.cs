using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemys;
    public GameObject mapManager;
    Tile[,] mapTiles;
    Enemy[] enemies;

    private void Start()
    {    
        enemies = new Enemy[enemys.Length];
        for (int i = 0; i < enemys.Length; i++)
        {
            enemies[i] = enemys[i].GetComponent<Enemy>();
        }
        mapTiles = mapManager.GetComponent<MapManager>().mapTiles;
    }

    public void EnemysMove()
    {
        int a = 0;
        foreach (Enemy en in enemies)
        {
            en.EnemyMove();
        }
    }

    public void EnemysColliderOn()
    {
        foreach (Enemy en in enemies)
        {
            en.OnCillider();
        }
    }


    private void EnemyMove(int enemyNum, int a) //움직임 여기서 구현하자
    {
    }
}
