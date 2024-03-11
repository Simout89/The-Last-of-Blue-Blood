using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudHealth : MonoBehaviour
{
    [SerializeField] Sprite NormalHealth;
    [SerializeField] Sprite BreakHealth;
    [SerializeField] Sprite HealHealth;
    private Image Image;
    private int LastHealth = 5;
    private int NewHealth;
    private bool _first = false;
    private void Awake()
    {
        Image = GetComponent<Image>();
        PlayerHealth.OnChangeHealth.AddListener(HandleChangeHealth);
    }
    private void HandleChangeHealth(int health)
    {
        if(_first)
        {
            NewHealth = health;
            if (LastHealth > NewHealth)
                StartCoroutine(ChangeHealth(true));
            else
                StartCoroutine(ChangeHealth(false));

            LastHealth = NewHealth;
        }else
        {
            _first = true;
        }
    }
    private IEnumerator ChangeHealth(bool flag)
    {
        if(flag)
        {
            Image.sprite = BreakHealth;
            yield return new WaitForSeconds(0.3f);
            Image.sprite = NormalHealth;
        }else
        {
            Image.sprite = HealHealth;
            yield return new WaitForSeconds(0.4f);
            Image.sprite = NormalHealth;
        }
    }
}
