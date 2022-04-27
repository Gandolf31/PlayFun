//==============================================================
// HealthSystem
// HealthSystem.Instance.TakeDamage (float Damage);
// HealthSystem.Instance.HealDamage (float Heal);
// HealthSystem.Instance.UseMana (float Mana);
// HealthSystem.Instance.RestoreMana (float Mana);
// Attach to the Hero.
//==============================================================

using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

    public static HealthSystem Instance;

    public ParticleSystem particle;    
    public AudioSource audio;
    public Image currentHealthBar;
    public Image currentHealthGlobe;
    public Text healthText;
    public float hitPoint = 100f;
    public float maxHitPoint = 100f;

    public Image currentManaBar;
    public Image currentManaGlobe;
    public Text manaText;
    public float manaPoint = 100f;
    public float maxManaPoint = 100f;

    //==============================================================
    // Regenerate Health & Mana
    //==============================================================
    public bool Regenerate = true;
    public float regen = 0.1f;
    private float timeleft = 0.0f;  // Left time for current interval
    public float regenUpdateInterval = 1f;

    public bool GodMode;
    public GameObject Player;

    //골매니저
    [SerializeField] GameObject goalManager;
    GoalManager goal;
    //==============================================================
    // Awake
    //==============================================================
    void Awake()
    {
        Instance = this;
    }

    //==============================================================
    // Awake
    //==============================================================
    void Start()
    {
        UpdateGraphics();
        timeleft = regenUpdateInterval;
        goal = goalManager.GetComponent<GoalManager>();

    }

    //==============================================================
    // Update
    //==============================================================
    void Update()
    {
        if (Regenerate)
            Regen();
    }

    //==============================================================
    // Regenerate Health & Mana
    //==============================================================
    private void Regen()
    {
        timeleft -= Time.deltaTime;

        if (timeleft <= 0.0) // Interval ended - update health & mana and start new interval
        {
            // Debug mode
            if (GodMode)
            {
                HealDamage(maxHitPoint);
                RestoreMana(maxManaPoint);
            }
            else
            {
                HealDamage(regen);
                RestoreMana(regen);
            }

            UpdateGraphics();

            timeleft = regenUpdateInterval;
        }
    }

    //==============================================================
    // Health Logic
    //==============================================================
    private void UpdateHealthBar()
    {
        float ratio = hitPoint / maxHitPoint;
        currentHealthBar.rectTransform.localPosition = new Vector3(currentHealthBar.rectTransform.rect.width * ratio - currentHealthBar.rectTransform.rect.width, 0, 0);
        healthText.text = hitPoint.ToString("0") + "/" + maxHitPoint.ToString("0");
    }

    private void UpdateHealthGlobe()
    {
        float ratio = hitPoint / maxHitPoint;
        currentHealthGlobe.rectTransform.localPosition = new Vector3(0, currentHealthGlobe.rectTransform.rect.height * ratio - currentHealthGlobe.rectTransform.rect.height, 0);
        healthText.text = hitPoint.ToString("0") + "/" + maxHitPoint.ToString("0");
    }

    public void TakeDamage(float Damage)
    {
        hitPoint -= Damage;
        if (hitPoint < 1)
            hitPoint = 0;
        if (hitPoint != 0)
        {
            PlayerController pc = Player.GetComponent<PlayerController>();
            Animator animator = Player.GetComponent<Animator>();
            //
            StartCoroutine(Ghost(pc));
            animator.SetTrigger("Damaged");
            particle.Play();
            audio.Play();
        }
        UpdateGraphics();

        StartCoroutine(PlayerHurts());

    }

    public void HealDamage(float Heal)
    {
        hitPoint += Heal;
        if (hitPoint > maxHitPoint)
            hitPoint = maxHitPoint;

        UpdateGraphics();
    }
    public void SetMaxHealth(float max)
    {
        maxHitPoint += (int)(maxHitPoint * max / 100);

        UpdateGraphics();
    }

    //==============================================================
    // Mana Logic
    //==============================================================
    private void UpdateManaBar()
    {
        float ratio = manaPoint / maxManaPoint;
        currentManaBar.rectTransform.localPosition = new Vector3(currentManaBar.rectTransform.rect.width * ratio - currentManaBar.rectTransform.rect.width, 0, 0);
        manaText.text = manaPoint.ToString("0") + "/" + maxManaPoint.ToString("0");
    }

    private void UpdateManaGlobe()
    {
        float ratio = manaPoint / maxManaPoint;
        currentManaGlobe.rectTransform.localPosition = new Vector3(0, currentManaGlobe.rectTransform.rect.height * ratio - currentManaGlobe.rectTransform.rect.height, 0);
        manaText.text = manaPoint.ToString("0") + "/" + maxManaPoint.ToString("0");
    }

    public void UseMana(float Mana)
    {
        manaPoint -= Mana;
        if (manaPoint < 1) // Mana is Zero!!
            manaPoint = 0;

        UpdateGraphics();
    }

    public void RestoreMana(float Mana)
    {
        manaPoint += Mana;
        if (manaPoint > maxManaPoint)
            manaPoint = maxManaPoint;

        UpdateGraphics();
    }
    public void SetMaxMana(float max)
    {
        maxManaPoint += (int)(maxManaPoint * max / 100);

        UpdateGraphics();
    }

    //==============================================================
    // Update all Bars & Globes UI graphics
    //==============================================================
    private void UpdateGraphics()
    {
        UpdateHealthBar();
        UpdateHealthGlobe();
        UpdateManaBar();
        UpdateManaGlobe();
    }

    //==============================================================
    // Coroutine Player Hurts
    //==============================================================
    IEnumerator PlayerHurts()
    {
        // Player gets hurt. Do stuff.. play anim, sound..

        //PopupText.Instance.Popup("Ouch!", 1f, 1f); // Demo stuff!

        if (hitPoint < 1) // Health is Zero!!
        {
            // Hero is Dead
            Debug.Log("Game Over");
            goal.Fail();
            Animator animator = Player.GetComponent<Animator>();
            animator.SetBool("isDie", true);
        }

        else
            yield return null;
    }

    //고스트화
    IEnumerator Ghost(PlayerController pc)
    {
        Debug.Log(1);
        pc.LayerChange(13);
        yield return new WaitForSeconds(2f);
        pc.LayerChange(9);
    }
}
