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
    [SerializeField]
    float waitTime;

    private AI ai;

    private void Start()
    {
        ai = GetComponent<AI>();
    }

    public override void atk()
    {
        coroutine = spray1(waitTime, degrees, 0, true);
        StartCoroutine(coroutine);


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

    public override void stopAtk()
    {
        if (coroutine!=null)
        {
            StopCoroutine(coroutine);
        }
    }
}
