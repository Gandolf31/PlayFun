using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public ParticleSystem particleSlow;

    [SerializeField] float moveLength;
    [SerializeField] float actionScend;
    [SerializeField] Transform weaponPoint;
    [SerializeField] Vector3 dir = new Vector3();
    [SerializeField] GameObject throwingWeapon;
    [SerializeField] Queue<GameObject> weaponQueue = new Queue<GameObject>();
    [SerializeField] AudioSource audio;

    Vector3 destPos = new Vector3();
    TimingManager theTimingManager;
    Camar cam;
    Rigidbody a;
    bool canMove = true;
    bool stop = false;
    float time;
    Animator m_Animator;


    private void Start()
    {
        theTimingManager = FindObjectOfType<TimingManager>();
        cam = FindObjectOfType<Camar>();
        a = this.gameObject.GetComponent<Rigidbody>();

        // weapon 포인트 지점에 3개생성      
        for (int i = 0; i < 3; i++)
        {
            weaponQueue.Enqueue(Instantiate(throwingWeapon, weaponPoint));
        }

        m_Animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W))
        {
            if (canMove)
            {
                // 판정 체크
                if (theTimingManager.CheckTiming())
                {
                    StartAction();
                    m_Animator.SetTrigger("Go");
                    transform.LookAt(transform.position + new Vector3(dir.z, 0, -dir.x));
                    audio.Play();
                }
            }

        }
        else if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (canMove)
            {
                // 판정 체크
                if (theTimingManager.CheckTiming())
                {
                    StartCoroutine(AttackAction());
                    m_Animator.SetTrigger("Attack");
                }
            }
        }
    }

    void StartAction()
    {
        // while 사용 해서 움직임시간으로 변경   
        // 방향계산
        dir.Set(-Input.GetAxisRaw("Vertical") * moveLength, 0, Input.GetAxisRaw("Horizontal") * moveLength);
        // 이동 목표값 계산
        destPos = transform.position + new Vector3(dir.x, 0, dir.z);
        StartCoroutine(MoveCo());
        StartCoroutine(cam.ZoomCam());
    }

    IEnumerator AttackAction()
    {
        canMove = false;
        //weapon shot
        GameObject now = weaponQueue.Dequeue();
        now.SetActive(true);
        Rigidbody ri = now.GetComponent<Rigidbody>();
        float s = now.GetComponent<Weapon>().speed;
        ri.velocity = -weaponPoint.right * s;
        yield return new WaitForSeconds(actionScend);
        now.SetActive(false);
        now.GetComponent<Rigidbody>().velocity = Vector3.zero;
        now.transform.position = weaponPoint.position;
        weaponQueue.Enqueue(now);

        canMove = true;
    }

    IEnumerator MoveCo()
    {
        canMove = false;
        a.velocity = dir * moveSpeed;
        yield return new WaitForSeconds(actionScend);
        a.velocity = Vector3.zero;
        canMove = true;
        // m_Animator.SetTrigger("Go");


        /*while (Vector3.D(transform.position - destPos)>= 0.001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destPos, moveSpeed * Time.deltaTime);       
        }
        transform.position = destPos;*/
    }


    public void StopMove(bool stop)
    {
        canMove = stop;
    }

    public void MoveSpeedSlow(float speed)
    {
        moveSpeed = speed;
        particleSlow.Play();
    }

    public void MoveSpeedUp(float speed)
    {
        moveSpeed = speed;
        particleSlow.Stop();

    }
    public void LayerChange(int layerNum)
    {
        //Player 9, Ghost 13
        gameObject.layer = layerNum;
    }

    
}
