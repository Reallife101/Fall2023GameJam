using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedControl : MonoBehaviour
{
    public SpriteRenderer bimbus;
    public SpriteRenderer bimbus2;
    public Image fadeImage;
    private Material _material;
    private Material _material2;
    private Material _materialFade;
    public float wipeDuration;
    private Vector3 start;
    private Vector3 end;
    public RectTransform wiper;
    public RectTransform endWiper;
    public float wipeSpeedMod;
    // Start is called before the first frame update
    void Start()
    {
        start = wiper.position;
        end = endWiper.position;
        _material = bimbus.material;
        _material2 = bimbus2.material;
        _materialFade = fadeImage.material;
        _material.SetColor("_Scroll_Dir", new Vector4(3, 0, 0, 0));
        _material2.SetColor("_Scroll_Dir", new Vector4(3, 0, 0, 0));
        _materialFade.SetFloat("_Wipe_Progress", 2);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetSpeed(float speed)
    {
        _material.SetColor("_Scroll_Dir", new Vector4(speed, 0, 0, 0));
        _material2.SetColor("_Scroll_Dir", new Vector4(speed, 0, 0, 0));
    }

    public void Wipe()
    {
        StartCoroutine(StartWipe());
    }

    IEnumerator StartWipe()
    {
        float timePassed = 0;
        while (timePassed < wipeDuration)
        {
            timePassed += Time.deltaTime;
            float progress = Mathf.Lerp(2, -1, timePassed / wipeDuration);
            _materialFade.SetFloat("_Wipe_Progress", progress);
            wiper.position = Vector3.Lerp(start, end, timePassed * wipeSpeedMod / wipeDuration);
            yield return null;
        }
    }
}
