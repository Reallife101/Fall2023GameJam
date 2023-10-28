using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprayAttack : Attacks
{
    [SerializeField]
    float spawnInfront;

    private EnemyAI ai;

    private void Start()
    {
        ai = GetComponent<EnemyAI>();
    }

    public override void atk()
    {
        Instantiate(projectile, transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward * (-50)));
        Instantiate(projectile, transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward * (-40)));
        Instantiate(projectile, transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward * (-30)));
        Instantiate(projectile, transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward * (-20)));
        Instantiate(projectile, transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward * (-10)));
        Instantiate(projectile, transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward));
        Instantiate(projectile, transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward * (10)));
        Instantiate(projectile, transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward * (20)));
        Instantiate(projectile, transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward * (30)));
        Instantiate(projectile, transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward * (40)));
        Instantiate(projectile, transform.position + transform.up * spawnInfront, transform.rotation * Quaternion.Euler(Vector3.forward * (50)));
        StartCoroutine(waitEnable());


    }

    IEnumerator waitEnable()
    {
        yield return new WaitForSeconds(.1f);
        ai.canAttack = true;
    }
}
