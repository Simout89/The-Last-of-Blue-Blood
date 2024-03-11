using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudHealthText : MonoBehaviour
{
    private TMP_Text m_Text;
    private void Awake()
    {
        m_Text = GetComponent<TMP_Text>();
        PlayerHealth.OnChangeHealth.AddListener(HandleChangeHealth);
    }
    private void HandleChangeHealth(int health)
    {
        m_Text.text = health.ToString();
    }
}
