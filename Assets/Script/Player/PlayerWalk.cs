using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerWalk : MonoBehaviour
{
    [SerializeField] private float Speed = 1f;
    private float _movespeedmultiplier = 1;
    private Rigidbody _rb;
    private PlayerInput _playerinput;
    private void HandeIsGround(bool flag)
    {
        if (flag)
            _movespeedmultiplier = 1;
        else
            _movespeedmultiplier = 0.5f;
    }
    private void Awake()
    {
        _playerinput = GetComponent<PlayerInput>();
        _rb = GetComponent<Rigidbody>();
        PlayerCheckGround.IsGround.AddListener(HandeIsGround);
    }
    
    private void Update()
    {
        Vector3 velocity = new Vector3(_playerinput.Horizontal, 0, 0) * Speed * _movespeedmultiplier;
        velocity.y = _rb.velocity.y;
        Vector3 worldVelocity = transform.TransformVector(velocity);
        _rb.velocity = worldVelocity;
    }
}
