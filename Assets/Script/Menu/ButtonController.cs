using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{

    public static UnityEvent OnPlayButton = new UnityEvent();
    [SerializeField] private GameObject authormenu;
    [SerializeField] private GameObject settingsmenu;
    [SerializeField] private Slider slidervolume;

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
        authormenu.SetActive(!authormenu.active);
    }
    public void SettingsButton()
    {
        settingsmenu.SetActive(!settingsmenu.active);
    }
    public void ChangeVolume()
    {
        AudioListener.volume = slidervolume.value;
    }
}
