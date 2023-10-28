using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiAttack : Attacks
{
    [SerializeField]
    private List<Attacks> attackList;

    public override void atk()
    {
        foreach (Attacks attack in attackList)
        {
            attack.atk();
        }
    }


}
