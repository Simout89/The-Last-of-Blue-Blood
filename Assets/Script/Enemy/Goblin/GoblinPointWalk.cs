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
            StartCoroutine(GotoPoint1());
        else
            StartCoroutine(GotoPoint2());
    }
    IEnumerator GotoPoint1()
    {
        if (Vector3.Distance(_goblininput.GoblinBody.transform.position, _goblininput.Point1) < 0.1)
        {
            yield return new WaitForSeconds(StayDelay);
            _target = false;
        }
        else
        {
            Vector3 direction = (_goblininput.Point1 - _goblininput.GoblinBody.transform.position).normalized;
            _goblininput.GoblinRigidbody.MovePosition(_goblininput.GoblinRigidbody.position + direction * Speed * Time.fixedDeltaTime);
        }
    }
    IEnumerator GotoPoint2()
    {
        if (Vector3.Distance(_goblininput.GoblinBody.transform.position, _goblininput.Point2) < 0.1)
        {
            yield return new WaitForSeconds(StayDelay);
            _target = true;
        }
        else
        {
            Vector3 direction = (_goblininput.Point2 - _goblininput.GoblinBody.transform.position).normalized;
            _goblininput.GoblinRigidbody.MovePosition(_goblininput.GoblinRigidbody.position + direction * Speed * Time.fixedDeltaTime);
        }
    }
}
