using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HudFinishTime : MonoBehaviour
{
    private TMP_Text text;
    public static UnityEvent<string> OnSetFinishTimeText = new UnityEvent<string>();
    private void Awake()
    {
        OnSetFinishTimeText.AddListener(HandleSetFinishTimeText);
        text = GetComponent<TMP_Text>();
    }
    private void HandleSetFinishTimeText(string time)
    {
        text.text = time;
    }
}
