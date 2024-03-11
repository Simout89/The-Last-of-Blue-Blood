using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static UnityEvent DamageToPlayer = new UnityEvent();
    public static UnityEvent<int> OnChangeHealth = new UnityEvent<int>();
    public static UnityEvent HealthPlayer = new UnityEvent();
    [SerializeField] public int Health = 3;
    private int maxHealth;
    private void Awake()
    {
        maxHealth = Health;
        HealthPlayer.AddListener(HandleHealthPlayer);
        DamageToPlayer.AddListener(Damage);
        StartCoroutine(Delay());
    }

    private void HandleHealthPlayer()
    {
        if(maxHealth > Health)
        {
            Health++;
            CheckHealth();
            OnChangeHealth.Invoke(Health);
        }
    }

    private void Damage()
    {
        Health--;
        CheckHealth();
        OnChangeHealth.Invoke(Health);
    }

    private void CheckHealth()
    {
        if (Health <= 0)
        {
            HudTimer.FixTime.Invoke();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.1f);
        OnChangeHealth.Invoke(Health);
    }
}
