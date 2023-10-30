using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openSfx : MonoBehaviour
{
    [SerializeField] FMODUnity.EventReference OpenButton;

    public void callUIAudio()
    {
        FMODUnity.RuntimeManager.PlayOneShot(OpenButton);
    }
}
