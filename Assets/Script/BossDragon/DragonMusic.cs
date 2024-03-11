using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMusic : MonoBehaviour
{
    [SerializeField] private AudioClip Music;
    private AudioSource audioSource;
    private void Awake()
    {
        DragonTrigger.OnBossFight.AddListener(HandleBossFight);
        audioSource = GetComponent<AudioSource>();
    }

    private void HandleBossFight(bool arg0)
    {
        audioSource.clip = Music;
        audioSource.Play();
    }
}
