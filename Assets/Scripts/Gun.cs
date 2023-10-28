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
    [SerializeField] private int loadSize;
    [SerializeField] protected float coneSize;
    private float fClock;
    private float rClock;
    private int inLoad;



    // Start is called before the first frame update
    void Start()
    {
        fClock = 0;
        rClock = 0;
        inLoad = loadSize;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = FindObjectOfType<Camera>().ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - gameObject.transform.position;
        Vector2 velocity = (new Vector2(direction.x, direction.y)).normalized;

        
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            reload();
        }
        if (Input.GetMouseButton(0) && fClock <= 0 && inLoad > 0 && rClock <= 0)
        {
            shoot();
            
            if (inLoad == 0)
            {
                reload();
            }
        }
        Aim(velocity, fClock <= 0 || rClock > 0);


        fClock -= Time.deltaTime;
        rClock -= Time.deltaTime;
    }

    virtual protected void shoot()
    {
        transform.rotation = Quaternion.AngleAxis(UnityEngine.Random.Range(-coneSize / 2f, coneSize / 2f), new Vector3(0, 0, 1)) * transform.rotation;
        Instantiate(bullet, transform.position, Quaternion.identity);
        fClock = fireDelay;
        inLoad -= 1;
        FindObjectOfType<GunUI>().updateUI(inLoad);
    }

    private void Aim(Vector2 dir, bool complete)
    {
        if (!complete)
        {
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg)), transform.rotation, .75f * Mathf.Pow(0.5f, Time.deltaTime));
        }
        else 
        {
            transform.rotation = Quaternion.Euler(0, 0, (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg));
        }
    }

    private void reload()
    {
        inLoad = loadSize;
        rClock = reloadDelay;
        FindObjectOfType<GunUI>().reload(reloadDelay);
    }

    public int getBullets()
    {
        return inLoad;
    }

    public int getMax()
    {
        return loadSize;
    }
}
