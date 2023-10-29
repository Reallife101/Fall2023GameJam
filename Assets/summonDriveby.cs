using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summonDriveby : Attacks
{
    private GameObject[] spawns;
    [SerializeField]
    int waves;
    [SerializeField]
    private GameObject enemy;
    private AI ai;

    public override void atk()
    {
        coroutine = waitEnable();
        StartCoroutine(coroutine);
    }

    public override void stopAtk()
    {
        if (coroutine != null)
        {

            StopCoroutine(coroutine);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spawns = GameObject.FindGameObjectsWithTag("Spawn");
        ai = GetComponent<AI>();
    }

    IEnumerator waitEnable()
    {
        for (int i = 0; i < waves; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(enemy, spawns[Random.Range(0, spawns.Length)].transform.position, Quaternion.identity);

        }


        ai.canAttack = true;
    }
}
