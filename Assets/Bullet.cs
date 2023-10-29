using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;
    [SerializeField] protected int pointsOnHit;
    Vector2 velocity;
    [SerializeField] protected GameObject spark;
    // Start is called before the first frame update
    virtual protected void Start()
    {
        Vector2 velocity = (transform.right).normalized * speed;
        rb.velocity = velocity;
        Destroy(gameObject, 1.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="borders")
        {
            if (spark != null)
            {
                Instantiate(spark, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }

        AI enemy = collision.gameObject.GetComponent<AI>();

        if (enemy)
        {
            enemy.takeDamage(damage);
            pointManager.PM_Instance.GainPoint(pointsOnHit);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AI enemy = collision.gameObject.GetComponent<AI>();

        if (enemy)
        {
            enemy.takeDamage(damage);
            pointManager.PM_Instance.GainPoint(pointsOnHit);
            Destroy(gameObject);
        }
    }
}
