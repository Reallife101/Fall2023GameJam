using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchWeapons : MonoBehaviour
{
    [SerializeField] List<GameObject> weapons;
    [SerializeField] List<GameObject> UI;
    [SerializeField]
    private GameObject spark;

    public void UIOn(int i)
    {
        allOff();
        if (spark != null)
        {
            Instantiate(spark, transform.position, Quaternion.identity);
        }

        weapons[i].SetActive(true);
        UI[i].SetActive(true);

    }

    public void allOff()
    {
        foreach (GameObject go in weapons)
        {
            go.SetActive(false);
        }

        foreach (GameObject go in UI)
        {
            go.SetActive(false);
        }
    }

}
