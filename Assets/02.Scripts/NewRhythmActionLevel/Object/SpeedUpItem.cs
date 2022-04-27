using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : MonoBehaviour
{
    float TurnSpeed = 100f;
    NoteManager noteManager;
    MeshRenderer meshRenderer;
    Animator animator;
    public GameObject Note;

    void Start()
    {
        noteManager = Note.GetComponent<NoteManager>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, TurnSpeed * Time.deltaTime, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //아이템 효과
            //노트 스크립트를 참조해서 아이템 먹으면 bpm이 N배 정도 빨라짐
            StartCoroutine(ChangeBPM());
            animator.SetBool("isGet", true);
        }
    }

    IEnumerator ChangeBPM()
    {
        meshRenderer.enabled = false;
        noteManager.bpm = 210;
        yield return new WaitForSeconds(2f);
        noteManager.bpm = 105;
        Destroy(gameObject);
    }
}
