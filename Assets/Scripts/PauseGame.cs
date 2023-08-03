using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    void OnEnable()
    {
        InputManager.pause += Pause;
      
    }

    void Pause(float state)
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 0f;
    }
}
