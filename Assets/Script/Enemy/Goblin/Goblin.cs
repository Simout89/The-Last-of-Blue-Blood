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

    private bool _berserk = false;
    private bool _target = true; // true = p1 , false = p2
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
        if(_berserk)
        {
            berserkmode();
        }
        else
        {
            if (_target)
                StartCoroutine(GotoPoint1());
            else
                StartCoroutine(GotoPoint2());
        }
    }
    private void berserkmode()
    {
        Rotate();
        if (Vector3.Distance(Body.transform.position, player.transform.position) > 1.3)
        {
            Vector3 direction = (player.transform.position - Body.transform.position).normalized;
            direction.y = 0;
            BodyRB.MovePosition(BodyRB.position + direction * (Speed * 2) * Time.fixedDeltaTime);
        }
    }
    private void Rotate()
    {
        if (Body.transform.position.x - player.transform.position.x < 0f)
        {
            Vector3 currentRotation = Body.transform.rotation.eulerAngles;
            currentRotation.y = 180f;
            Body.transform.rotation = Quaternion.Euler(currentRotation);
        }
        else
        {
            Vector3 currentRotation = Body.transform.rotation.eulerAngles;
            currentRotation.y = 0f;
            Body.transform.rotation = Quaternion.Euler(currentRotation);
        }
    }
    IEnumerator GotoPoint1()
    {
        if (Vector3.Distance(Body.transform.position, _point1) < 0.1)
        {
            if(_berserk)
            {
                yield return new WaitForSeconds(StayDelay);
                Vector3 rotate = Body.transform.eulerAngles;
                rotate.y = 0;
                Body.transform.rotation = Quaternion.Euler(rotate);
                _target = false;
            }
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
            if(!_berserk)
            {
                yield return new WaitForSeconds(StayDelay);
                Vector3 rotate = Body.transform.eulerAngles;
                rotate.y = 180;
                Body.transform.rotation = Quaternion.Euler(rotate);
                _target = true;
            }
        }
        else
        {
            Vector3 direction = (_point2 - Body.transform.position).normalized;
            BodyRB.MovePosition(BodyRB.position + direction * Speed * Time.fixedDeltaTime);
        }
    }
    private bool _playernear()
    {
        if(Vector3.Distance(Body.transform.position, player.transform.position) < 10)
        {
            if (_raycastcheck())
                _berserk = true;
        }
        if (Vector3.Distance(Body.transform.position, player.transform.position) < PlayerDistanceDetection)
            return true;
        else
            return false;
    }
    private bool _raycastcheck()
    {
        var direction = player.transform.position - Body.transform.position;
        RaycastHit hit;
        if (Physics.Raycast(Body.transform.position, direction, out hit, PlayerDistanceDetection))
        {
            if ((hit.collider.gameObject.tag == "Player") || (hit.collider.gameObject.tag == "Gun"))
                return true;
            else
                return false;
        }
        else
            return false;
    }
}
