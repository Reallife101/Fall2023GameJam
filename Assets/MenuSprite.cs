using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSprite : MonoBehaviour
{
    private float accTime = 0;
    private void Start()
    {
        transform.position = new Vector2(UnityEngine.Random.Range(-6f, 6f), 7.5f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position = new Vector2(transform.position.x, transform.position.y -Time.deltaTime * 15);
        accTime += Time.deltaTime;
        if (accTime >= .8975f)
        {
            transform.position = new Vector2(UnityEngine.Random.Range(-6f, 6f), 6);
            Debug.Log(accTime);
            accTime = 0;
        }
    }
}
