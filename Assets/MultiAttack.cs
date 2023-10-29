using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiAttack : Attacks
{
    [SerializeField]
    private List<Attacks> attackList;

    [SerializeField]
    private float waitTime;

    private bool canAttack;

    IEnumerator waitEnable()
    {
        yield return new WaitForSeconds(waitTime);
        canAttack = true;
    }

    private void Start()
    {
        canAttack = true;
    }

    public override void atk()
    {
        if (canAttack)
        {
            foreach (Attacks attack in attackList)
            {
                attack.atk();
            }
            canAttack = false;
            StartCoroutine(waitEnable());
        }

    }


    public override void stopAtk()
    {
        foreach (Attacks attack in attackList)
        {
            attack.stopAtk();
        }
    }
}
