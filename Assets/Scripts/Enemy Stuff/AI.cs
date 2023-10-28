using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AI : MonoBehaviour
{
    [SerializeField]
    public float Health;
    public bool canAttack;

    // Health Stuff
    public abstract void takeDamage(float dmg);

    public abstract void gainHealth(float hlth);

}
