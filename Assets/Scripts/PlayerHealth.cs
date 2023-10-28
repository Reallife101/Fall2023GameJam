using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public static event Action PlayerHitEvent;
    [SerializeField] int maxHealth;
    int currentHealth;
    [SerializeField] string enemyProjectileTag;
    bool invul = false;
    [SerializeField] int invulTime;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == enemyProjectileTag && !invul)
        {
            StartCoroutine(invincibilityCoroutine());
        }
    }

    private void TakeDamage()
    {
        PlayerHitEvent?.Invoke();
    }

    IEnumerator invincibilityCoroutine()
    {
        invul = true;
        yield return new WaitForSeconds(invulTime);
        invul = false;
    }
}
