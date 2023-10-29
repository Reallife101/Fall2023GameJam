using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] string OpeningCutsceneName;
    public void StartGame()
    {
        SceneManager.LoadScene(OpeningCutsceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
