using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject otherUI;

    private void Awake()
    {
        Time.timeScale = 1;
        PlayerHealth.PlayerDeathEvent += OnDie;
    }

    void OnDie()
    {
        gameOverUI.SetActive(true);
        otherUI.SetActive(false);
        Time.timeScale = 0;
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void OnDestroy()
    {
        PlayerHealth.PlayerDeathEvent -= OnDie;
    }
}
