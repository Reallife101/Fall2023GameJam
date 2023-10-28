using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : AI
{
    [SerializeField]
    private healthBar hb;

    [SerializeField]
    private List<Attacks> attackList;

    [SerializeField]
    private float delayBetweenAttacks;

    public bool canAttack;

    private float timeElapsed;
    private float currentHealth;
    private int currentPhase;


    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;
        currentPhase = 0;
        currentHealth = Health;
        hb.sliderMax(Health);
    }


    // Health Stuff
    public override void takeDamage(float dmg)
    {
        currentHealth -= dmg;
        hb.setSlider(currentHealth);

        if (currentHealth < 0)
        {
            Debug.Log("dead");
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

    public void goNextPhase()
    {

    }
}
