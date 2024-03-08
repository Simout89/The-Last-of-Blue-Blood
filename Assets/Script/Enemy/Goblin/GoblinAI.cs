using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class GoblinAI : MonoBehaviour
{
    private bool _rotate = true; // false - left , true - right
    private bool _newrotate = false;
    private bool _target = true;
    private bool _lasttarget = true;
    private string currentState;

    [SerializeField] private float PlayerDistanceDetection = 1f;
    private Vector3 Point1;
    private Vector3 Point2;
    [SerializeField] private float RotateSpeed = 1f;
    [SerializeField] private float Speed = 1f;
    [SerializeField] private float StayDelay = 1f;
    [SerializeField] public Transform Point;
    [SerializeField] public GameObject GoblinBody;
    [SerializeField] public Rigidbody GoblinRigidbody;
    [SerializeField] public GameObject Player;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform BodyPoint;
    private GoblinBody goblinbody;
    const string IDLE = "Armature|idle";
    const string WALK = "Armature|Patrolling";
    const string BERSERK = "Armature|Fury mode";
    const string ATTACK = "Armature|Attack ";
    private bool infattack = false;
    private void Awake()
    {
        Point1 = Point.position;
        Point2 = GoblinBody.transform.position;
        goblinbody = GetComponentInChildren<GoblinBody>();

    }
    private void Update()
    {
        if ((Vector3.Distance(GoblinBody.transform.position, Player.transform.position) < PlayerDistanceDetection) || infattack || goblinbody.getdamage)
        {
            infattack = true;
            if (goblinbody._damagedelay)
                ChangeAnimationState(BERSERK);
            else
                ChangeAnimationState(ATTACK);
            BerserkRotate();
            Vector3 direction = (Player.transform.position - BodyPoint.position).normalized;
            //direction.y = 0;
            GoblinRigidbody.MovePosition(GoblinRigidbody.position + direction * (Speed * 2.5f) * Time.deltaTime);
        }
        else
        {
            PointWalk();        
        }
    }
    private void BerserkRotate()
    {
        if (GoblinBody.transform.position.x - Player.transform.position.x < 0f)
        {
            _newrotate = true;
            if (_rotate != _newrotate)
            {
                _rotate = _newrotate;
                RotateRight();
            }
        }
        else
        {
            _newrotate = false;
            if (_rotate != _newrotate)
            {
                _rotate = _newrotate;
                RotateLeft();
            }
        }
    }
    private void RotateLeft()
    {
        StartCoroutine(Rotate(90f));
    }
    private void RotateRight()
    {
        StartCoroutine(Rotate(-90));
    }
    private IEnumerator Rotate(float angel)
    {
        Quaternion startRotation = GoblinBody.transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(0, angel, 0);
        float elapsedTime = 0.0f;
        while (elapsedTime < RotateSpeed)
        {
            GoblinBody.transform.localRotation = Quaternion.Slerp(startRotation, endRotation, (elapsedTime / RotateSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        GoblinBody.transform.localRotation = endRotation;
    }
    private void PointWalk()
    {
        if (_lasttarget != _target)
        {
            if (_lasttarget)
                RotateLeft();
            else
                RotateRight();
            _lasttarget = _target;
        }

        if (_target)
            StartCoroutine(GotoPoint(Point1, "Point1"));
        else
            StartCoroutine(GotoPoint(Point2, "Point2"));
    }
    IEnumerator GotoPoint(Vector3 Point, string PointName)
    {
        if (Vector3.Distance(GoblinBody.transform.position, Point) < 0.2)
        {
            ChangeAnimationState(IDLE);
            yield return new WaitForSeconds(StayDelay);
            _target = PointName == "Point1" ? false : true;

        }
        else
        {
            ChangeAnimationState(WALK);
            Vector3 direction = (Point - GoblinBody.transform.position).normalized;
            GoblinRigidbody.MovePosition(GoblinRigidbody.position + direction * Speed * Time.deltaTime);
        }

    }
    private void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        _animator.Play(newState);
        currentState = newState;
    }
}
