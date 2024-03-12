using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragonHealth : MonoBehaviour
{
    public static UnityEvent<int> OnGetDamage = new UnityEvent<int>();
    public static UnityEvent OnDeath = new UnityEvent();
    
    [SerializeField] private int health = 5;
    [SerializeField] private GameObject Dragon;
    private bool Damable = false;
    private ParticleSystem particle;
    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        DragonPatrol.OnBossPatrol.AddListener(HandleBossPatrol);
        DragonIdle.OnBossIdle.AddListener(HandleBossIdle);
        OnGetDamage.Invoke(health);
    }

    private void HandleBossIdle(bool arg0)
    {
        if(arg0)
            Damable = false;
    }

    private void HandleBossPatrol(bool arg0)
    {
        if(arg0)
            Damable = true;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if ((collision.gameObject.tag == "Bullet") && Damable)
        {
            health--;
            OnGetDamage.Invoke(health);
            CheckHealth();
        }
    }
    private void CheckHealth()
    {
        if (health == 0)
        {
            OnDeath.Invoke();
            particle.Play();
            StartCoroutine(delay());
        }
    }
    private IEnumerator delay()
    {
        yield return new WaitForSeconds(5);
        Destroy(Dragon);
        DragonTrigger.OnBossFight.Invoke(false);
    }
}
