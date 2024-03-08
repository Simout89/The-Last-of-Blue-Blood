using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float JumpForce = 1f;
    private Rigidbody _rb;
    private bool _isground = false;
    private bool _isjumpdelay = true;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        PlayerInput.OnJump.AddListener(HandleJump);
        PlayerCheckGround.IsGround.AddListener(HandeIsGround);
        PlayerJumpDelay.OnJumpDelayOutput.AddListener(HandleJumpDelayOutput);
    }

    private void HandleJump()
    {
        if(_isground && _isjumpdelay)
        {
            PlayerJumpDelay.OnJumpDelayInput.Invoke();
            _rb.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
        }
    }
    private void HandeIsGround(bool flag)
    {
        _isground = flag;
    }
    private void HandleJumpDelayOutput(bool flag)
    {
        _isjumpdelay = flag;
    }
}
