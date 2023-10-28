using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;
    Vector2 velocity;
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
            Destroy(gameObject);
        }

        AI enemy = collision.gameObject.GetComponent<AI>();

        if (enemy)
        {
            enemy.takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
