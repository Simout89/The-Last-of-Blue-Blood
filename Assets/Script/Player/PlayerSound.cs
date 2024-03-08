using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioClip Walk;
    private AudioSource audioSource;
    private PlayerInput _playerinput;
    private bool _isPlaying = false;
    private bool _isground = false;

    private void Awake()
    {
        _playerinput = GetComponent<PlayerInput>();
        audioSource = GetComponent<AudioSource>();
        PlayerCheckGround.IsGround.AddListener(HandeIsGround);

    }
    private void Update()
    {
        if ((_playerinput.Horizontal != 0) && !_isPlaying && _isground)
        {
            StartCoroutine(DelayWalk());
        }

    }
    private IEnumerator DelayWalk()
    {
        _isPlaying = true;
        audioSource.PlayOneShot(Walk);
        yield return new WaitForSeconds(Walk.length);
        _isPlaying = false;
    }
    private void HandeIsGround(bool flag)
    {
        _isground = flag;
    }
}
