using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStopOnDestroy : MonoBehaviour
{
    [SerializeField] float timeStopTime;
    private void OnDestroy()
    {
        TimeManager.Instance.TimeSlow(timeStopTime);
    }
}
