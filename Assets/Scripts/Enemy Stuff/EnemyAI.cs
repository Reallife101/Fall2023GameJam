using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float Health;

    [SerializeField]
    private List<Attacks> attackList;

    [SerializeField]
    private float delayBetweenAttacks;

    public bool canAttack;

    private float timeElapsed;
    private float currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;
        currentHealth = Health;
    }


    // Health Stuff
    public void takeDamage(float dmg)
    {
        currentHealth -= dmg;

        if (currentHealth < 0)
        {
            Destroy(gameObject);
        }

    }

    public void gainHealth(float hlth)
    {
        currentHealth += hlth;

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
}
