using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    public  void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void ChangeScenebyName(string name)
    {
        if(name!=null)
        {
            SceneManager.LoadScene(name);
            Time.timeScale = 1f;
        }
    }
}
