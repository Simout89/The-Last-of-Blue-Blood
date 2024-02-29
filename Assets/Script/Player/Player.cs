using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed = 5f;
    [SerializeField] private float JumpForce = 1f;
    [SerializeField] private float HeightJumpForce = 1f;
    [SerializeField] private float HeightJumpCD = 1f;
    [SerializeField] private float HP = 3f;
    private bool _heightjumpcd = true;
    private bool _isgrounded = false;
    private Rigidbody _rb;

    private void Start()
    {
        EventManager.Ground.AddListener(CheckGround);
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Jump();
        HeightJump();
        Move();
    }
    private void CheckGround(bool flag)
    {
        _isgrounded = flag;
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isgrounded)
        {
            _rb.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
        }
    }
    private void HeightJump()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && _isgrounded && _heightjumpcd)
        {
            StartCoroutine(heightjumpcd());
            _rb.AddForce(Vector3.up * HeightJumpForce, ForceMode.VelocityChange);
        }
    }
    private IEnumerator heightjumpcd()
    {
        _heightjumpcd = false;
        yield return new WaitForSeconds(HeightJumpCD);
        _heightjumpcd = true;
    }
    private void Move()
    {
        Vector3 velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0) * Speed;
        velocity.y = _rb.velocity.y;
        Vector3 worldVelocity = transform.TransformVector(velocity);
        _rb.velocity = worldVelocity;
    }
}
