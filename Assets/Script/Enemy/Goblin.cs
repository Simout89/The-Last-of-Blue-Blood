using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Goblin : MonoBehaviour
{
    [SerializeField] private int Health = 5;
    [SerializeField] private float Speed = 1f;
    [SerializeField] private float StayDelay = 1f;
    [SerializeField] Transform Point;
    private Vector3 _point1;
    private Vector3 _point2;
    private Rigidbody _rb;
    private bool target = true; // true = p1 , false = p2
    private bool _playernear = false;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _point1 = Point.position;
        _point2 = gameObject.transform.position;
    }
    private void Update()
    {
        CheckPlayerNear();
    }
    private void CheckPlayerNear()
    {
        if(_playernear)
        {
            ChangeTarget();
        }
    }
    private void ChangeTarget()
    {
        if (target)
            GotoPoint1();
        else
            GotoPoint2();
    }
    private void GotoPoint1()
    {
        Vector3 direction = (_point1 - transform.position).normalized;
        _rb.MovePosition(_rb.position + direction * Speed * Time.fixedDeltaTime);
        if(Vector3.Distance(transform.position, _point1) < 0.1)
            target = false;
    }
    private void GotoPoint2()
    {
        Vector3 direction = (_point2 - transform.position).normalized;
        _rb.MovePosition(_rb.position + direction * Speed * Time.fixedDeltaTime);
        if (Vector3.Distance(transform.position, _point2) < 0.1)
            target = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Health--;
            CheckHealt();
        }
        if(collision.gameObject.tag == "Player")
        {
            EventManager.damageplayer();
        }
    }
    private void CheckHealt()
    {
        if (Health <= 0)
            Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            _playernear = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            _playernear = false;
    }
}
