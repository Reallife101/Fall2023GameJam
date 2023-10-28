using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attacks : MonoBehaviour
{
    [SerializeField]
    public GameObject projectile;
    public abstract void atk();
    public abstract void stopAtk();
    public  IEnumerator coroutine;
}
