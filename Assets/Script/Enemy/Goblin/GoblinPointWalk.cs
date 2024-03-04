using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class GoblinPointWalk : MonoBehaviour
{
    [SerializeField] private float Speed = 1f;
    [SerializeField] private float StayDelay = 1f;
    private GoblinInput _goblininput;
    private bool _target = true;
    private bool _lasttarget = true;
    public static UnityEvent OnPointWalk = new UnityEvent();

    private void Awake()
    {
        OnPointWalk.AddListener(HandlePointWalk);
        _goblininput = GetComponent<GoblinInput>();
    }
    private void HandlePointWalk()
    {
        if(_lasttarget != _target)
        {
            if (_lasttarget)
                GoblinRotate.OnRotateLeft.Invoke();
            else
                GoblinRotate.OnRotateRight.Invoke();
            _lasttarget = _target;
        }

        if (_target)
            StartCoroutine(GotoPoint(_goblininput.Point1, "Point1"));
        else
            StartCoroutine(GotoPoint(_goblininput.Point2, "Point2"));
    }
    IEnumerator GotoPoint(Vector3 Point, string PointName)
    {
        if (Vector3.Distance(_goblininput.GoblinBody.transform.position, Point) < 0.1)
        {
            yield return new WaitForSeconds(StayDelay);
            _target = PointName == "Point1" ? false : true;
        }
        else
        {
            Vector3 direction = (Point - _goblininput.GoblinBody.transform.position).normalized;
            _goblininput.GoblinRigidbody.MovePosition(_goblininput.GoblinRigidbody.position + direction * Speed * Time.fixedDeltaTime);
        }

    }
}
