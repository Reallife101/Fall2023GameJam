using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] private string NextSceneName;
    [SerializeField] private string hitlessScene;
    [SerializeField] private PlayerHealth health;

    public void LoadScene()
    {
        if(health != null && health.getHealth() == 3)
        {
            SceneManager.LoadScene(hitlessScene);
        }
        else
        {
            SceneManager.LoadScene(NextSceneName);
        }
    }

}
