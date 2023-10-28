using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossAI : AI
{
    [SerializeField]
    private healthBar hb;

    [SerializeField]
    private TMP_Text phaseName;

    [SerializeField]
    private List<Attacks> allAttacks;

    private List<Attacks> attackList;

    [SerializeField]
    private List<BossPhaseSO> phases;

    [SerializeField]
    private float delayBetweenAttacks;

    [SerializeField]
    private Animator hbAnimator;
    public bool invincible;

    private float timeElapsed;
    private float currentHealth;
    private int currentPhase;


    // Start is called before the first frame update
    void Start()
    {
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
        if (canAttack)
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= delayBetweenAttacks)
            {
                attackList[Random.Range(0, attackList.Count)].atk();
                timeElapsed = 0;
                canAttack = false;
            }
        }
    }

    IEnumerator goNextPhase()
    {
        invincible = true;
        hbAnimator.SetBool("down", true);
        yield return new WaitForSeconds(3f);
        currentPhase += 1;
        if (currentPhase >= phases.Count)
        {
            Debug.Log("Win");
        }
        else
        {
            updatePhase();
            hbAnimator.SetBool("down", false);
            yield return new WaitForSeconds(3f);
            invincible = false;
        }    
    }

    public void updatePhase()
    {
        phaseName.text = phases[currentPhase].name;
        Health = phases[currentPhase].maxHealth;
        currentHealth = Health;
        hb.sliderMax(Health);

        //Deal with Attacks
        attackList.Clear();
        foreach (int index in phases[currentPhase].attackListIndex)
        {
            attackList.Add(allAttacks[index]);
        }
    }

}
