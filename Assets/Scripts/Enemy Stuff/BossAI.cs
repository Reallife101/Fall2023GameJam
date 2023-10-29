using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossAI : AI
{
    public static event System.Action BossDies;

    [SerializeField]
    private GameObject warning;

    [SerializeField]
    private healthBar hb;

    [SerializeField]
    private switchWeapons sw;

    [SerializeField]
    private TMP_Text phaseName;

    [SerializeField]
    private List<Attacks> allAttacks;

    private List<Attacks> attackList;

    [SerializeField]
    private List<BossPhaseSO> phases;

    private float delayBetweenAttacks;

    [SerializeField]
    private Animator hbAnimator;
    [SerializeField]
    private Animator bossAnimator;
    [SerializeField]
    private Animator borderAnimator;
    public bool invincible;

    private float timeElapsed;
    private float currentHealth;
    private int currentPhase;

    [SerializeField] private float timeStopLength;

    [SerializeField]
    private List<GameObject> sprites;

    [SerializeField] FMODUnity.EventReference bossShoot;
    [SerializeField] FMODUnity.EventReference warningSound;

    // Start is called before the first frame update
    void Start()
    {
        delayBetweenAttacks = 1;
        attackList = new List<Attacks>();
        timeElapsed = 0;
        currentPhase = 0;
        updatePhase();
    }


    // Health Stuff
    public override void takeDamage(float dmg)
    {
        if (invincible)
        {
            return;
        }
        
        currentHealth -= dmg;
        hb.setSlider(currentHealth);

        if (currentHealth < 0)
        {
            foreach(Attacks attack in attackList)
            {
                attack.stopAtk();
            }
            TimeManager.Instance.TimeSlow(timeStopLength);
            StartCoroutine(goNextPhase());
        }

    }

    public override void gainHealth(float hlth)
    {
        currentHealth += hlth;
        hb.setSlider(currentHealth);

        if (currentHealth > Health)
        {
            currentHealth = Health;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth > Health/2)
        {
            delayBetweenAttacks = 1;
        }
        else if (currentHealth > Health / 4)
        {
            delayBetweenAttacks = .5f;
        }
        else
        {
            delayBetweenAttacks = 0f;
        }

        if (canAttack)
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= delayBetweenAttacks)
            {
                attackList[Random.Range(0, attackList.Count)].atk();
                FMODUnity.RuntimeManager.PlayOneShot(bossShoot);
                timeElapsed = 0;
                canAttack = false;
            }
        }
    }

    IEnumerator goNextPhase()
    {
        invincible = true;
        hbAnimator.SetBool("down", true);
        bossAnimator.SetBool("up", false);
        yield return new WaitForSeconds(1f);
        if (warning != null && currentPhase < phases.Count)
        {
            Instantiate(warning, new Vector3(0,0,0), Quaternion.identity);
            FMODUnity.RuntimeManager.PlayOneShot(warningSound);
        }
        yield return new WaitForSeconds(2f);
        currentPhase += 1;
        if (currentPhase >= phases.Count)
        {
            BossDies?.Invoke();
        }
        else
        {
            borderAnimator.SetTrigger(phases[currentPhase].BorderTrigger);
            updatePhase();
            hbAnimator.SetBool("down", false);
            bossAnimator.SetBool("up", true);
            yield return new WaitForSeconds(3f);
            canAttack = true;
            invincible = false;
        }    
    }

    public void updatePhase()
    {
        phaseName.text = phases[currentPhase].phaseName;
        Health = phases[currentPhase].maxHealth;
        currentHealth = Health;
        hb.sliderMax(Health);
        sw.UIOn(currentPhase);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("bossPhase", phases[currentPhase].bossPhase);

        foreach (GameObject sp in sprites)
        {
            sp.SetActive(false);
        }
        sprites[currentPhase].SetActive(true);
        //Deal with Attacks
        attackList.Clear();
        foreach (int index in phases[currentPhase].attackListIndex)
        {
            attackList.Add(allAttacks[index]);
        }
    }

}
