using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] List<GameObject> heartContainer;
    int heartIndex;
    [SerializeField] float flashbangTime;
    [SerializeField] Image flashbangImage;
    [SerializeField] AnimationCurve flashbangCurve;
    Coroutine flashbangCoroutine = null;

    private void Awake()
    {
        foreach(GameObject i in heartContainer)
        {
            i.SetActive(true);
        }
        heartIndex = heartContainer.Count - 1;
        PlayerHealth.PlayerHitEvent += PlayerHit;
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            PlayerHit();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerHealed();
        }
        
    }

    void PlayerHit()
    {
        heartContainer[heartIndex].SetActive(false);
        --heartIndex;
        heartIndex = Mathf.Clamp(heartIndex, 0, heartContainer.Count - 1);

        if (flashbangCoroutine != null)
        {
            StopCoroutine(flashbangCoroutine);
        }
        flashbangCoroutine = StartCoroutine(Flashbang());
    }

    void PlayerHealed()
    {

        heartContainer[heartIndex].SetActive(true);
        ++heartIndex;
        heartIndex = Mathf.Clamp(heartIndex, 0, heartContainer.Count - 1);
    }

    IEnumerator Flashbang()
    {
        float timePassed = 0;
        while(timePassed < flashbangTime)
        {
            timePassed += Time.deltaTime;
            Color flashbangColor = flashbangImage.color;
            flashbangColor.a = flashbangCurve.Evaluate(timePassed / flashbangTime);
            flashbangImage.color = flashbangColor;
            yield return null;
        }
    }


    private void OnDestroy()
    {
        PlayerHealth.PlayerHitEvent -= PlayerHit;
    }
}
