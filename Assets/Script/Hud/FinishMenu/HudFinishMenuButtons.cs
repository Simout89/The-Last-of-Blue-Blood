using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HudFinishMenuButtons : MonoBehaviour
{
    [SerializeField] private string NextLevelName;
    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(NextLevelName);
    }
}
