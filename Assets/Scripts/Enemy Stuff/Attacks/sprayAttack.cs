using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprayAttack : Attacks
{
    [SerializeField]
    float spawnInfront;
    [SerializeField]
    int waves;
    [SerializeField]
    float timeBetweenWaves;
    [SerializeField]
    bool alternate;

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

    private void instantiateBullets()
    {
        Instantiate(projectile, transform.position + transform.up* spawnInfront, transform.rotation* Quaternion.Euler(Vector3.forward* (-50)));
        Instantiate(projectile, transform.position + transform.up* spawnInfront, transform.rotation* Quaternion.Euler(Vector3.forward* (-40)));
        Instantiate(projectile, transform.position + transform.up* spawnInfront, transform.rotation* Quaternion.Euler(Vector3.forward* (-30)));
        Instantiate(projectile, transform.position + transform.up* spawnInfront, transform.rotation* Quaternion.Euler(Vector3.forward* (-20)));
        Instantiate(projectile, transform.position + transform.up* spawnInfront, transform.rotation* Quaternion.Euler(Vector3.forward* (-10)));
        Instantiate(projectile, transform.position + transform.up* spawnInfront, transform.rotation* Quaternion.Euler(Vector3.forward));
        Instantiate(projectile, transform.position + transform.up* spawnInfront, transform.rotation* Quaternion.Euler(Vector3.forward* (10)));
        Instantiate(projectile, transform.position + transform.up* spawnInfront, transform.rotation* Quaternion.Euler(Vector3.forward* (20)));
        Instantiate(projectile, transform.position + transform.up* spawnInfront, transform.rotation* Quaternion.Euler(Vector3.forward* (30)));
        Instantiate(projectile, transform.position + transform.up* spawnInfront, transform.rotation* Quaternion.Euler(Vector3.forward* (40)));
        Instantiate(projectile, transform.position + transform.up* spawnInfront, transform.rotation* Quaternion.Euler(Vector3.forward* (50)));
    }

    private void instantiateBullets2()
    {
        Instantiate(projectile, transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward * (-45)));
        Instantiate(projectile, transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward * (-35)));
        Instantiate(projectile, transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward * (-25)));
        Instantiate(projectile, transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward * (-15)));
        Instantiate(projectile, transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward * (-5)));
        Instantiate(projectile, transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward * (5)));
        Instantiate(projectile, transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward * (15)));
        Instantiate(projectile, transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward * (25)));
        Instantiate(projectile, transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward * (35)));
        Instantiate(projectile, transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward * (45)));
    }

    IEnumerator waitEnable()
    {
        for (int i=0; i<waves; i++)
        {
            if (alternate && i % 2 == 1)
            {
                instantiateBullets2();
            }
            else
            {
                instantiateBullets();
            }

            yield return new WaitForSeconds(timeBetweenWaves);
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
