using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudPrincessCount : MonoBehaviour
{
    private int _princesscount = 0;
    private TMP_Text Text;
    private void Start()
    {
        Text = GetComponent<TMP_Text>();
        PrincessCollect.OnCollectPrincess.AddListener(HandlePrincessCollect);
    }

    private void HandlePrincessCollect()
    {
        _princesscount++;
        Text.text = _princesscount.ToString();
    }
}
