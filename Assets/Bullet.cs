using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float damage;
    Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 mousePos = FindObjectOfType<Camera>().ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - FindObjectOfType<Gun>().gameObject.transform.position;
        Vector2 velocity = (FindObjectOfType<Gun>().gameObject.transform.right).normalized * speed;
        rb.velocity = velocity;
        transform.rotation = Quaternion.Euler(0, 0, (Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg));
        Destroy(gameObject, 1.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       AI enemy = collision.gameObject.GetComponent<AI>();

        if (enemy)
        {
            enemy.takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
