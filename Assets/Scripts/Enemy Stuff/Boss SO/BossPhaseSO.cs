using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BossPhaseSO", order = 1)]
public class BossPhaseSO : ScriptableObject
{
    public string phaseName;

    public float maxHealth;
    
    public List<int> attackListIndex;
}

