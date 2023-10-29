using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class GameWin : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject gameWinUI;
    private void Awake()
    {
        BossAI.BossDies += OnBossDeath;
        gameWinUI.SetActive(false);
    }

    void OnBossDeath()
    {
        gameWinUI.SetActive(true);
        scoreText.text = "Final Score: " + pointManager.PM_Instance.totalPoints;
    }

    private void OnDestroy()
    {
        BossAI.BossDies -= OnBossDeath;
    }
}
