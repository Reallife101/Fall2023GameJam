using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 mousePos = FindObjectOfType<Camera>().ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - FindObjectOfType<Gun>().gameObject.transform.position;
        Vector2 velocity = (new Vector2(direction.x, direction.y)).normalized * speed;
        rb.velocity = velocity;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
