using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;

    [SerializeField] GameObject healthSystem;
    [SerializeField] Transform tfNoteAppear = null;

    public int bpm = 0;

    double currentTime = 0d;
    HealthSystem HPSys;
    TimingManager theTimingManager;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        theTimingManager = GetComponent<TimingManager>();
        HPSys = healthSystem.GetComponent<HealthSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 60d/ bpm)
        {
            GameObject t_note = ObjectPool.instnace.noteQueue.Dequeue();
            t_note.transform.position = tfNoteAppear.position;
            t_note.SetActive(true);
            
            //GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);
            //t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
            currentTime -= 60d / bpm;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
           
            if (collision.GetComponent<UnityEngine.UI.Image>().enabled)
            {
                HPSys.TakeDamage(5f);
            }
            
            theTimingManager.boxNoteList.Remove(collision.gameObject);
            ObjectPool.instnace.noteQueue.Enqueue(collision.gameObject);
            collision.gameObject.SetActive(false);
            collision.GetComponent<Note>().OnNoteImage();
        }
    }
}
