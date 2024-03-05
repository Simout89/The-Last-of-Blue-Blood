using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HudFinishMenuButtons : MonoBehaviour
{
    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
