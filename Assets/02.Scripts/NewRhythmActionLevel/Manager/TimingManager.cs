using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();
    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null;
    public GameObject effect;


    Vector2[] timingBoxs = null;


    void Start()
    {
        // 타이밍 박스 설정
       
        timingBoxs = new Vector2[timingRect.Length];

        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2, Center.localPosition.x + timingRect[i].rect.width / 2); //판정 범위
        }
    }


    public bool CheckTiming()
    {
        Animator animator = effect.GetComponent<Animator>();
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosx = boxNoteList[i].transform.localPosition.x;

            for (int j = 0; j<timingBoxs.Length; j++)
            {
                if (timingBoxs[j].x <= t_notePosx && t_notePosx <= timingBoxs[j].y)
                {
                    animator.SetTrigger("EffectOn");
                    boxNoteList[i].GetComponent<Note>().HideNote();          
                    boxNoteList.RemoveAt(i);
                    //Debug.Log("hit" + j);
                    return true;
                }
            }
        }
        Debug.Log("Miss");
        //캐릭터 hp 깎임
        HealthSystem.Instance.TakeDamage(10f);
        return false;
    }
}
