using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float Speed = 5f;
    [SerializeField] private float JumpForce = 1f;
    [SerializeField] private float HeightJumpForce = 1f;
    [SerializeField] private float HeightJumpCD = 1f;
    private int _prinesscount = 0;
    private bool _heightjumpcd = true;
    private bool _isgrounded = false;
    private Rigidbody _rb;

    void Start()
    {
        EventManager.Princess.AddListener(PrincessCollect);
        EventManager.Ground.AddListener(CheckGround);
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Jump();
        HeightJump();
        Move();
    }
    void CheckGround(bool flag)
    {
        _isgrounded = flag;
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isgrounded)
        {
            _rb.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
        }
    }
    void HeightJump()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && _isgrounded && _heightjumpcd)
        {
            StartCoroutine(heightjumpcp());
            _rb.AddForce(Vector3.up * HeightJumpForce, ForceMode.VelocityChange);
        }
    }
    IEnumerator heightjumpcp()
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
    private void PrincessCollect()
    {
        _prinesscount++;
    }

}
