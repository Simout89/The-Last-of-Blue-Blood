using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class HudHightJumpDelayText : MonoBehaviour
{
    public static UnityEvent<bool> OnHeightJumpDelayState = new UnityEvent<bool>();

    private TMP_Text text;
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        PlayerHeightJump.OnHeightJump.AddListener(HandleHeightJump);
    }
    private void HandleHeightJump(int timedelay)
    {
        StartCoroutine(StartTimer(timedelay));
    }
    IEnumerator StartTimer(int timedelay)
    {
        OnHeightJumpDelayState.Invoke(true);
        float timer = timedelay;
        while (timer >= 0f)
        {
            timer -= Time.deltaTime;
            string seconds = Mathf.Floor(timer).ToString();
            text.text = seconds;
            yield return null;
        }
        OnHeightJumpDelayState.Invoke(false);
        text.text = "";
    }
}
