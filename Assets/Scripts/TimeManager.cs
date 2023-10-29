using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] AnimationCurve timeStopCurve;
    public static TimeManager Instance { get; private set; }
    private float slowTime;

    // Start is called before the first frame update

    private void Awake()
    {

        if(Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    public void TimeSlow(int time)
    {

    }
}
