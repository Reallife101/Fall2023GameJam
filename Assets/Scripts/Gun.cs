using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Vector3 mousePos;
    [SerializeField] private Camera cam;
    [SerializeField] private Bullet bullet;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float fireDelay;
    [SerializeField] private float reloadDelay;
    [SerializeField] private float loadSize;
    private float fClock;
    private float rClock;
    private float inClip;



    // Start is called before the first frame update
    void Start()
    {
        fClock = 0;
        rClock = 0;
        inClip = loadSize;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = FindObjectOfType<Camera>().ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - FindObjectOfType<Gun>().gameObject.transform.position;
        Vector2 velocity = (new Vector2(direction.x, direction.y)).normalized;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg);
        

        if (Input.GetMouseButton(0) && fClock <= 0 && inClip > 0 && rClock <= 0)
        {
            shoot();
            fClock = fireDelay;
            inClip -= 1;
            if (inClip == 0)
            {
                reload();
            }
        }

        fClock -= Time.deltaTime;
        rClock -= Time.deltaTime;
    }

    private void shoot()
    {
        Instantiate(bullet, transform);
    }

    private void reload()
    {
        inClip = loadSize;
        rClock = reloadDelay;
    }
}
