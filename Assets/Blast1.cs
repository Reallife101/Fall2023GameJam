using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] FMODUnity.EventReference blastChargeSound;

    // Update is called once per frame
    public void callBlastAudio()
    {
        FMODUnity.RuntimeManager.PlayOneShot(blastChargeSound);
    }
}
