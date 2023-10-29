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

    [SerializeField]
    List<GameObject> projectiles;

    private AI ai;

    private void Start()
    {
        ai = GetComponent<AI>();
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
            Instantiate(projectiles[Random.Range(0,projectiles.Count)], transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward));
            yield return new WaitForSeconds(waitTime);
        }

        ai.canAttack = true;
    }

    public override void stopAtk()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }
}
