using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] private string NextSceneName;

    public void LoadScene()
    {
        SceneManager.LoadScene(NextSceneName);
    }

}
