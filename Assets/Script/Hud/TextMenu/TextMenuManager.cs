using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TextMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject TextMenu;
    [SerializeField] private TMP_Text tMP;
    [SerializeField] float speed = 1f;
    public static UnityEvent<string> OnTextMenu = new UnityEvent<string>();
    private IEnumerator coroutine;
    private void Awake()
    {
        OnTextMenu.AddListener(HandleTextMenu);
    }

    private void HandleTextMenu(string arg0)
    {
        coroutine = WriteText(arg0);
        StartCoroutine(coroutine);
    }
    private IEnumerator WriteText(string arg0)
    {
        tMP.text = "";
        PlayerInput.OnInputState.Invoke(false);
        TextMenu.SetActive(true);
        char[] chars = arg0.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            tMP.text += chars[i];
            yield return new WaitForSeconds(speed);
        }
        yield return new WaitForSeconds(1f);
    }
    public void CloseButton()
    {
        StopCoroutine(coroutine);
        TextMenu.SetActive(false);
        PlayerInput.OnInputState.Invoke(true);
    }
}
