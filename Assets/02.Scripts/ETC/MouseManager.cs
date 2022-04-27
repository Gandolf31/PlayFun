using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour
{
    private GameObject Clicked;
    LevelManager levelManager;
    StageSelectManager stageManager;
    public RaycastHit hit;
    private void Start()
    {
        stageManager = StageSelectManager.stageManager;
        levelManager = LevelManager.levelManager;
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f))
        {
            switch (hit.collider.gameObject.layer)//마우스 올려 놨을 때
            {
                case 8://levelselection
                    ObjectClick(8, hit);
                    break;
                case 9://tile
                    ObjectClick(9, hit);
                    break;
                case 10://button
                    ObjectClick(10, hit);
                    break;
            }
        }

    }

    void ObjectClick(int layer,RaycastHit hit)//클릭할때
    {//ui 위치에서는 안되게 하기
        if (Input.GetMouseButtonUp(0))
        {
            Clicked = hit.collider.gameObject;
            switch (layer)
            {
                case 8:
                    /*
                    if (Clicked.GetComponent<StagePopUp>().CheckInside())
                    {
                        Clicked.GetComponent<StagePopUp>().levelToLoad();
                    }
                    */
                    break;
                case 9:
                    Tile hitTile = hit.collider.gameObject.GetComponent<Tile>();
                    if (hitTile.isMarking)
                    {
                        levelManager.PlayerTurnAdd(hitTile.pos);
                    }
                    break;
                case 10:
                    hit.collider.gameObject.GetComponent<Button>().hit();
                    break;
            }
        }

    }

}
