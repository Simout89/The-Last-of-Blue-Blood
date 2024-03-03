using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public static UnityEvent DamageToPlayer = new UnityEvent();
    [SerializeField] private float Health = 3f;
    private void Awake()
    {
        DamageToPlayer.AddListener(Damage);
    }
    private void Damage()
    {
        Health--;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (Health <= 0)
            Debug.Log("Die");
    }
}
