using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(PlayerInput))]
public class PlayerWalk : MonoBehaviour
{
    [SerializeField] private float Speed = 1f;
    [SerializeField] private GameObject Body;
    [SerializeField] private float RotateSpeed = 1f;
    private bool _rotate = true; // false - left , true - right
    private bool _newrotate = false;
    private float _movespeedmultiplier = 1;
    private float _squadmovespeedmultiplier = 1;
    private Rigidbody _rb;
    private PlayerInput _playerinput;
    private void HandeIsGround(bool flag)
    {
        if (flag)
            _movespeedmultiplier = 1;
        else
            _movespeedmultiplier = 0.7f;
    }
    private void Awake()
    {
        _playerinput = GetComponent<PlayerInput>();
        _rb = GetComponent<Rigidbody>();
        PlayerInput.OnSquat.AddListener(HandleSquat);
        PlayerCheckGround.IsGround.AddListener(HandeIsGround);
    }

    private void HandleSquat(bool arg0)
    {
        if(arg0)
            _squadmovespeedmultiplier = 0.8f;
        else
            _squadmovespeedmultiplier = 1f;
    }

    private void Update()
    {
        if (_playerinput.Horizontal > 0)
        {
            _newrotate = true;
            if (_rotate != _newrotate)
            {
                _rotate = _newrotate;
                RotateRight();
            }
        }
        else if (_playerinput.Horizontal < 0)
        {
            _newrotate = false;
            if (_rotate != _newrotate)
            {
                _rotate = _newrotate;
                RotateLeft();
            }
        }
        Vector3 velocity = new Vector3(_playerinput.Horizontal, 0, 0) * Speed * _movespeedmultiplier * _squadmovespeedmultiplier;
        velocity.y = _rb.velocity.y;
        Vector3 worldVelocity = transform.TransformVector(velocity);
        _rb.velocity = worldVelocity;
    }
    private void RotateLeft()
    {
        StartCoroutine(Rotate(-100f));
    }
    private void RotateRight()
    {
        StartCoroutine(Rotate(100f));
    }
    private IEnumerator Rotate(float angel)
    {
        Quaternion startRotation = Body.transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(0, angel, 0);
        float elapsedTime = 0.0f;
        while (elapsedTime < RotateSpeed)
        {
            Body.transform.localRotation = Quaternion.Slerp(startRotation, endRotation, (elapsedTime / RotateSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Body.transform.localRotation = endRotation;
    }
}
