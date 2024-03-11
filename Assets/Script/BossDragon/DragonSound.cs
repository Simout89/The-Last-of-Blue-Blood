using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSound : MonoBehaviour
{
    [SerializeField] private AudioClip Death;
    [SerializeField] private AudioClip Roar;
    [SerializeField] private AudioClip Land;
    [SerializeField] private AudioClip Fireball;
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        DragonHealth.OnDeath.AddListener(HandleDeath);
        DragonTrigger.OnBossFight.AddListener(HandleBossFight);
        DragonIdle.OnBossIdle.AddListener(HandleBossIdle);
        DragonAttack.OnCastFireBall.AddListener(HandleCastFireBall);
        DragonPatrol.OnBossPatrol.AddListener(HandleBossPatrol);
    }

    private void HandleBossPatrol(bool arg0)
    {
        if(arg0)
            audioSource.Play();
        else
            audioSource.Stop();
    }

    private void HandleCastFireBall()
    {
        audioSource.PlayOneShot(Fireball);
    }

    private void HandleBossIdle(bool arg0)
    {
        if (arg0)
            StartCoroutine(delay());
    }

    private void HandleBossFight(bool arg0)
    {
        if (arg0)
            audioSource.PlayOneShot(Roar);
    }
    private void HandleDeath()
    {
        audioSource.PlayOneShot(Death);
    }
    private IEnumerator delay()
    {
        yield return new WaitForSeconds(1.2f);
        audioSource.PlayOneShot(Land);
    }
}
