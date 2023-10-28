using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackDebug : Attacks
{
    [SerializeField]
    string debugString;

    public override void atk()
    {
        Debug.Log(debugString);
    }

    public override void stopAtk()
    {
        Debug.Log("stop Attack");
    }
}
