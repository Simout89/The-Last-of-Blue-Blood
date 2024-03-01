using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Goblin : MonoBehaviour
{
    [SerializeField] private int Health = 5;
    [SerializeField] private float Speed = 1f;
    [SerializeField] private float StayDelay = 1f;
    [SerializeField] private float PlayerDistanceDetection = 1f;
    [SerializeField] Transform Point;
    private GameObject player;
    private Vector3 _point1;
    private Vector3 _point2;
    private Rigidbody _rb;
    private bool target = true; // true = p1 , false = p2
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _point1 = Point.position;
        _point2 = gameObject.transform.position;
        player = GameObject.Find("Player");
    }
    private void FixedUpdate()
    {
        CheckPlayerNear();
    }
    private void CheckPlayerNear()
    {
        if(_playernear())
        {
            ChangeTarget();
        }
    }
    private void ChangeTarget()
    {
        if (target)
            StartCoroutine(GotoPoint1());
        else
            StartCoroutine(GotoPoint2());
    }
    IEnumerator GotoPoint1()
    {
        if (Vector3.Distance(transform.position, _point1) < 0.1)
        {
            yield return new WaitForSeconds(StayDelay);
            target = false;
        }
        else
        {
            Vector3 direction = (_point1 - transform.position).normalized;
            _rb.MovePosition(_rb.position + direction * Speed * Time.fixedDeltaTime);
        }
    }
    IEnumerator GotoPoint2()
    {
        if (Vector3.Distance(transform.position, _point2) < 0.1)
        {
            yield return new WaitForSeconds(StayDelay);
            target = true;
        }
        else
        {
            Vector3 direction = (_point2 - transform.position).normalized;
            _rb.MovePosition(_rb.position + direction * Speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Health--;
            CheckHealt();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EventManager.damageplayer();
        }
    }
    private void CheckHealt()
    {
        if (Health <= 0)
            Destroy(gameObject);
    }
    private bool _playernear()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < PlayerDistanceDetection)
            return true;
        else
            return false;
    }
}
