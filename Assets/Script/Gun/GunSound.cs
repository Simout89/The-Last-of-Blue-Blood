using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSound : MonoBehaviour
{
    [SerializeField] private AudioClip Fire;
    [SerializeField] private AudioClip Reload;
    private AudioSource audioSource;
    private bool afterreload = false;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Gun.OnFireSound.AddListener(HandleFire);
        Gun.OnReloadSound.AddListener(HandleReload);
    }

    private void HandleFire()
    {
        audioSource.PlayOneShot(Fire);
    }
    private void HandleReload()
    {
        audioSource.PlayOneShot(Reload);
    }
}
