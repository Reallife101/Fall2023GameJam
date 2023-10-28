using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burstAttack : Attacks
{
    [SerializeField]
    float spawnInfront;
    [SerializeField]
    float waitTime;
    [SerializeField]
    int loopAmount;

    private EnemyAI ai;

    private void Start()
    {
        ai = GetComponent<EnemyAI>();
    }

    public override void atk()
    {
        coroutine = waitEnable();
        StartCoroutine(coroutine);


    }

    IEnumerator waitEnable()
    {
        for (int i = 0; i < loopAmount; i++)
        {
            Instantiate(projectile, transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward));
            yield return new WaitForSeconds(waitTime);
        }

        ai.canAttack = true;
    }

    public override void stopAtk()
    {
        StopCoroutine(coroutine);
    }
}
