using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public static event Action PlayerHitEvent;
    public static event Action PlayerHealEvent;
    public static event Action PlayerDeathEvent;
    [SerializeField] int maxHealth;
    int currentHealth;
    [SerializeField] string enemyProjectileTag;
    [SerializeField] string borderTag;
    bool invul = false;
    [SerializeField] int invulTime;
    [SerializeField] float timeSlowTime = 0.75f;

    [SerializeField]
    private GameObject explosion;
    [SerializeField] FMODUnity.EventReference takeDamageSound;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == enemyProjectileTag || collision.gameObject.tag == borderTag) && !invul)
        {
            StartCoroutine(invincibilityCoroutine());
            TakeDamage();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == enemyProjectileTag || collision.gameObject.tag == borderTag) && !invul)
        {
            StartCoroutine(invincibilityCoroutine());
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        PlayerHitEvent?.Invoke();
        currentHealth--;
        TimeManager.Instance.TimeSlow(timeSlowTime);
        FMODUnity.RuntimeManager.PlayOneShot(takeDamageSound);
        if(currentHealth <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            PlayerDeathEvent?.Invoke();
            Destroy(gameObject);
        }
    }

    private void Heal()
    {
        currentHealth++;
        PlayerHealEvent?.Invoke();
    }

    public int getHealth()
    {
        return currentHealth;
    }

    IEnumerator invincibilityCoroutine()
    {
        invul = true;
        yield return new WaitForSeconds(invulTime);
        invul = false;
    }
}
