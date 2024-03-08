using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHeightJump : MonoBehaviour
{
    [SerializeField] private float HeightJumpForce = 1f;
    [SerializeField] private int HeightJumpDelay = 5;
    private Rigidbody _rb;
    private bool _isground = false;
    private bool _heightjumpdelay = true;
    private bool _isjumpdelay = true;

    public static UnityEvent<int> OnHeightJump = new UnityEvent<int>();

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        PlayerInput.OnHeightJump.AddListener(HandleHeightJump);
        PlayerCheckGround.IsGround.AddListener(HandeIsGround);
        PlayerJumpDelay.OnJumpDelayOutput.AddListener(HandleJumpDelayOutput);
    }

    private void HandleHeightJump()
    {
        if (_isground && _heightjumpdelay && _isjumpdelay)
        {
            OnHeightJump.Invoke(HeightJumpDelay);
            PlayerJumpDelay.OnJumpDelayInput.Invoke();
            StartCoroutine(heightjumpdelay());
            _rb.AddForce(Vector3.up * HeightJumpForce, ForceMode.VelocityChange);
        }
    }
    private void HandeIsGround(bool flag)
    {
        _isground = flag;
    }
    private IEnumerator heightjumpdelay()
    {
        _heightjumpdelay = false;
        yield return new WaitForSeconds(HeightJumpDelay);
        _heightjumpdelay = true;
    }
    private void HandleJumpDelayOutput(bool flag)
    {
        _isjumpdelay = flag;
    }
}
