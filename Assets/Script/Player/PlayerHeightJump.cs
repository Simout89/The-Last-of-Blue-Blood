using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeightJump : MonoBehaviour
{
    [SerializeField] private float HeightJumpForce = 1f;
    [SerializeField] private float HeightJumpDelay = 1f;
    private Rigidbody _rb;
    private bool _isground = false;
    private bool _heightjumpdelay = true;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        PlayerInput.OnHeightJump.AddListener(HandleHeightJump);
        PlayerCheckGround.IsGround.AddListener(HandeIsGround);
    }

    private void HandleHeightJump()
    {
        if (_isground && _heightjumpdelay)
        {
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
}
