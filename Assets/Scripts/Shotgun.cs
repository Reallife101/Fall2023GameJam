using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void shoot()
    {
        Quaternion q;
        for (int i = 0; i < 5; i++)
        {
            q = Quaternion.AngleAxis((coneSize/5) * i -coneSize / 2f + UnityEngine.Random.Range(-coneSize / 8f, coneSize / 8f), new Vector3(0, 0, 1)) * transform.rotation;
            Instantiate(bullet, transform.position, q);
        }
        updateBullets();
    }
}
