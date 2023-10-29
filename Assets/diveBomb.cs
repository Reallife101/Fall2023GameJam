using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diveBomb : Attacks
{
    public float speed;
    public bool destroyAfterTime;
    public float destroytime;

    private float timer;

    private bool move;
    [SerializeField] FMODUnity.EventReference diveBombSound;

    private void Start()
    {
        timer = 0;
        move = true;
        coroutine = waitEnable();
        StartCoroutine(coroutine);
    }
    public override void atk()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            return;
        }
        Vector3 dirVec = transform.position - player.transform.position;
        float angle = Mathf.Atan2(dirVec.y, dirVec.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, (angle+90)));
        FMODUnity.RuntimeManager.PlayOneShot(diveBombSound);
    }


    private void Update()
    {
        if (move)
        {
            transform.position = transform.position + transform.up * speed * Time.deltaTime;
            timer = timer + Time.deltaTime;
        }

        if (destroyAfterTime && timer > destroytime)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "borders")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            //DoDamage
            Destroy(gameObject);
        }
    }
    public override void stopAtk()
    {
        //Later
    }

    IEnumerator waitEnable()
    {
        yield return new WaitForSeconds(2f);
        move = false;
        yield return new WaitForSeconds(.25f);
        atk();
        yield return new WaitForSeconds(.25f);
        speed = speed * 2;
        move = true;
    }

}
