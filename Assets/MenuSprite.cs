using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSprite : MonoBehaviour
{
    private void Start()
    {
        transform.position = new Vector2(UnityEngine.Random.Range(-6f, 6f), 10);
    }
    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector2(transform.position.x, transform.position.y -Time.deltaTime * 13);
        if (transform.position.y < -7)
        {
            transform.position = new Vector2(UnityEngine.Random.Range(-6f, 6f), 6);
        }
    }
}
