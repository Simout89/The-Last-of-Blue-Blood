using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor.VersionControl;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed = 5f;
    [SerializeField] private float JumpForce = 1f;
    [SerializeField] private float HeightJumpForce = 1f;
    [SerializeField] private float HeightJumpCD = 1f;
    [SerializeField] private float Health = 3f;
    [SerializeField] private GameObject body;
    private CapsuleCollider _capsule;
    private bool _heightjumpcd = true;
    private bool _isgrounded = false;
    private Rigidbody _rb;

    private void Start()
    {
        EventManager.DamagePlayer.AddListener(Damage);
        EventManager.Ground.AddListener(CheckGround);
        _rb = GetComponent<Rigidbody>();
        _capsule = GetComponent<CapsuleCollider>();
        
    }
    private void Update()
    {
        Jump();
        HeightJump();
        Move();
        Squat();
    }
    private void CheckGround(bool flag)
    {
        _isgrounded = flag;
    }
    private void Squat()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _capsule.height = 1f;
            body.transform.localScale = new Vector3(1f, 0.5f, 1f);
            Vector3 pos = transform.position;
            pos.y -= 0.409f;
            transform.position = pos;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _capsule.height = 2f;
            body.transform.localScale = new Vector3(1f, 1f, 1f);
            Vector3 pos = transform.position;
            pos.y += 0.409f;
            transform.position = pos;

        }
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
    private void Damage()
    {
        Health--;
        CheckHealth();
    }
    private void CheckHealth()
    {
        if (Health <= 0)
            Debug.Log("Die");
    }
}
