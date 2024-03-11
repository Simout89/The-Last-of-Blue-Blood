using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HudFinishMenuButtons : MonoBehaviour
{
    public static UnityEvent OnRestart = new UnityEvent();
    public static UnityEvent OnNext = new UnityEvent();
    [SerializeField] private string NextLevelName;
    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
        TotalTime.OnResetTime.Invoke();
    }
    public void RestartButton()
    {
        OnRestart.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        OnNext.Invoke();
        SceneManager.LoadScene(NextLevelName);
    }

}
