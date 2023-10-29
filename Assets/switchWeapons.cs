using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchWeapons : MonoBehaviour
{
    [SerializeField] List<GameObject> weapons;
    [SerializeField] List<GameObject> UI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UIOn(int i)
    {
        allOff();

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
