using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipCamera : Attacks
{
    public Animator animator;
    private AI ai;
    public override void atk()
    {
        StartCoroutine(waitEnable());
    }

    public override void stopAtk()
    {
        //skip
    }

    private void Start()
    {
        ai = GetComponent<AI>();
    }

    IEnumerator waitEnable()
    {
        animator.SetBool("up", false);
        yield return new WaitForSeconds(6f);
        ai.canAttack = true;
        yield return new WaitForSeconds(2f);
        animator.SetBool("up", true);
        ai.canAttack = true;
    }

}
