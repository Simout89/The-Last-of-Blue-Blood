using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudFinishMenu : MonoBehaviour
{
    [SerializeField] private GameObject finishmenu;
    private void Awake()
    {
        Finish.OnFinish.AddListener(HandelFinish);
    }
    private void HandelFinish()
    {
        finishmenu.SetActive(true);
    }
}
