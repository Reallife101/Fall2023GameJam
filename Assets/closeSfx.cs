using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeSfx : MonoBehaviour
{
    [SerializeField] FMODUnity.EventReference closeButton;

    public void callUIAudio()
    {
        FMODUnity.RuntimeManager.PlayOneShot(closeButton);
    }
}
