using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;
    [SerializeField] List<GameObject> otherUIs;

    private void Awake()
    {
        Time.timeScale = 1;
        PlayerHealth.PlayerDeathEvent += OnDie;
    }

    void OnDie()
    {
        gameOverUI.SetActive(true);
        foreach (GameObject go in otherUIs)
        {
            go.SetActive(false);
        }
        Time.timeScale = 0;
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Title");
    }

    private void OnDestroy()
    {
        PlayerHealth.PlayerDeathEvent -= OnDie;
    }
}
