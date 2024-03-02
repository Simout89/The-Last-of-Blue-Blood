using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Goblin : MonoBehaviour
{
    [SerializeField] private float Speed = 1f;
    [SerializeField] private float StayDelay = 1f;
    [SerializeField] private float PlayerDistanceDetection = 1f;
    [SerializeField] Transform Point;
    [SerializeField] GameObject Body;
    [SerializeField] private Rigidbody BodyRB;
    private GameObject player;
    private Vector3 _point1;
    private Vector3 _point2;
    private bool target = true; // true = p1 , false = p2
    private void Start()
    {
        _point1 = Point.position;
        _point2 = Body.transform.position;
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
    private 
    IEnumerator GotoPoint1()
    {
        if (Vector3.Distance(Body.transform.position, _point1) < 0.1)
        {
            yield return new WaitForSeconds(StayDelay);
            target = false;
        }
        else
        {
            Vector3 direction = (_point1 - Body.transform.position).normalized;
            BodyRB.MovePosition(BodyRB.position + direction * Speed * Time.fixedDeltaTime);
        }
    }
    IEnumerator GotoPoint2()
    {
        if (Vector3.Distance(Body.transform.position, _point2) < 0.1)
        {
            yield return new WaitForSeconds(StayDelay);
            target = true;
        }
        else
        {
            Vector3 direction = (_point2 - Body.transform.position).normalized;
            BodyRB.MovePosition(BodyRB.position + direction * Speed * Time.fixedDeltaTime);
        }
    }
    private bool _playernear()
    {
        if (Vector3.Distance(Body.transform.position, player.transform.position) < PlayerDistanceDetection)
            return true;
        else
            return false;
    }
}
