using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] List<Image> heartContainer;
    [SerializeField] Sprite heart;
    int heartIndex;
    [SerializeField] float flashbangTime;
    [SerializeField] Image flashbangImage;
    [SerializeField] AnimationCurve flashbangCurve;
    Coroutine flashbangCoroutine = null;

    private void Awake()
    {
        foreach(Image i in heartContainer)
        {
            i.sprite = heart;
        }
        heartIndex = heartContainer.Count - 1;
        PlayerHealth.PlayerHitEvent += PlayerHit;
    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerHit();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerHealed();
        }
        */
    }

    void PlayerHit()
    {
        heartContainer[heartIndex].sprite = null;
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
        
        heartContainer[heartIndex].sprite = heart;
        ++heartIndex;
        heartIndex = Mathf.Clamp(heartIndex, 0, heartContainer.Count - 1);
    }

    IEnumerator Flashbang()
    {
        float timePassed = 0;
        while(timePassed < flashbangTime)
        {
            Debug.Log(timePassed);
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
