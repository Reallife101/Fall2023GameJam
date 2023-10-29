using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GunUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI textMesh;
    private int max;
    void Start()
    {
        Gun gun = FindObjectOfType<Gun>();
        max = gun.getMax();
        textMesh.text = max + " / " + max;
    }

    public void updateUI(int bullets)
    {
        textMesh.text = bullets + " / " + max;
    }

    public void setMax(int maxB)
    {
        this.max = maxB;
        textMesh.text = this.max + " / " + this.max;
    }

    public void reload(float duration)
    {
        textMesh.text = "reloading";
        StartCoroutine(reloadRoutine(duration));
    }

    IEnumerator reloadRoutine(float duration)
    {
        yield return new WaitForSeconds(duration / 4);
        textMesh.text += ".";
        yield return new WaitForSeconds(duration / 4);
        textMesh.text += ".";
        yield return new WaitForSeconds(duration / 4);
        textMesh.text += ".";
        yield return new WaitForSeconds(duration / 4);
        textMesh.text = max + " / " + max;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
