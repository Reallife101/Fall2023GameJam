using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machineGunAttack : Attacks
{
    [SerializeField]
    float spawnInfront;
    [SerializeField]
    int degreeStep;
    [SerializeField]
    float degrees;
    [SerializeField]
    int maxBullet;
    [SerializeField]
    int maxSpread;

    private EnemyAI ai;

    private void Start()
    {
        ai = GetComponent<EnemyAI>();
    }

    public override void atk()
    {
        StartCoroutine(spray1(0.1f, degrees, 0, true));


    }

    IEnumerator spray1(float waitTime, float degrees, int currentBullet, bool down)
    {
        yield return new WaitForSeconds(waitTime);

        int maxBullets = maxBullet;
        int deg = maxSpread;
        int stepSize = degreeStep;

        if (currentBullet > maxBullets)
        {
            ai.canAttack = true;
            yield break;
        }


        Instantiate(projectile, transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward * degrees));

        if (degrees >= deg)
        {
            degrees = deg - stepSize;
            down = true;
        }
        else if (degrees <= -deg)
        {
            degrees = -deg + stepSize;
            down = false;
        }
        else if (down)
        {
            degrees = degrees - stepSize;
        }
        else
        {
            degrees = degrees + stepSize;
        }


        StartCoroutine(spray1(waitTime, degrees, currentBullet + 1, down));
    }

}
