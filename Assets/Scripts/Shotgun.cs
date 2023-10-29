using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{

    // Update is called once per frame
    protected override void shoot()
    {
        Quaternion q;
        for (int i = 0; i < 7; i++)
        {
            q = Quaternion.AngleAxis((coneSize/7) * i -coneSize / 2f + UnityEngine.Random.Range(-coneSize / 8f, coneSize / 8f), new Vector3(0, 0, 1)) * transform.rotation;
            Instantiate(bullet, bulletSpot.transform.position, q);
        }
        CinemachineShake.Instance.ShakeCamera(shakeIntensity, shakeTime);
        updateBullets();
    }
}
