using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{

    public Tile[,] mapTiles;
    public int map_x, map_z;
    public GameObject player;
    public bool isWin;
    [SerializeField]
    GameObject[] enemy;

    void Start()//모든 맵에 있는 tile들 저장
    {
        Tile[] tiles = gameObject.GetComponentsInChildren<Tile>();
        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i].pos.x == 0)
            {
                map_z++;
            }
            if (tiles[i].pos.z == 0)
            {
                map_x++;
            }
        }
        mapTiles = new Tile[map_x, map_z];
        int a = 0;
        for (int i = 0; i < map_x; i++)
        {
            for (int j = 0; j < map_z; j++)
            {
                //Debug.Log(tiles[a].pos);
                int x = (int)tiles[a].pos.x;
                int z = (int)tiles[a].pos.z;
                mapTiles[x, z] = tiles[a++];
            }
        }
        PlayerMoveTileMarking();//시작 위치에서 움직일 수 있는 타일 표시
    }

    public void PlayerMoveTileMarking()//플레이어 현재 위치에서 움직일수 있는 타일 표시
    {
        Vector3 playerPos = player.transform.position;
        int x = (int)playerPos.x;
        int z = (int)playerPos.z;

        TileMarking(x+1, z, x+1 < map_x);
        TileMarking(x-1, z, x-1 > -1);
        TileMarking(x, z+1, z+1<map_z);
        TileMarking(x, z-1, z-1 > -1);
    }

    public void CleanTileMarking()// 모든 표시 삭제
    {
        for (int i = 0; i < map_x; i++)
        {
            for (int j = 0; j < map_z; j++)
            {
                Debug.Log(i +","+ j);
                mapTiles[i, j].Marking(false);
                mapTiles[i, j].isMarking = false;
            }
        }
    }

    void TileMarking(int x, int z, bool Baseline)
    {
        if (Baseline)
        {
            if (!mapTiles[x, z].isWall)
            {
                mapTiles[x, z].Marking(true);
                mapTiles[x, z].isMarking = true;
            }
        }

    }
}
