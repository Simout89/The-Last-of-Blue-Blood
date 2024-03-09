using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour
{
    private bool _authormenustate = false;
    public static UnityEvent OnPlayButton = new UnityEvent();
    [SerializeField] private GameObject authormenu;

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("exit");
    }
    public void PlayButton()
    {
        OnPlayButton.Invoke();
    }
    public void FateButton()
    {
        Application.OpenURL("https://t.me/fatex6510");
    }
    public void FilippButton()
    {
        Application.OpenURL("https://t.me/filippgora");
    }
    public void LopataButton()
    {
        Application.OpenURL("https://t.me/lopata_i_hleb");
    }

    public void AuthorButton()
    {
        authormenu.SetActive(!_authormenustate);
        _authormenustate = !_authormenustate;
    }
}
