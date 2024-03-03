using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float JumpForce = 1f;
    private Rigidbody _rb;
    private bool _isground = false;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        PlayerInput.OnJump.AddListener(HandleJump);
        PlayerCheckGround.IsGround.AddListener(HandeIsGround);
    }

    private void HandleJump()
    {
        if(_isground)
        {
            _rb.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
        }
    }
    private void HandeIsGround(bool flag)
    {
        _isground = flag;
    }
}
