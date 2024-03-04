using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoblinBerserk : MonoBehaviour
{
    [SerializeField] private float Speed = 1f;
    private GoblinInput _goblininput;
    public static UnityEvent OnBerserk = new UnityEvent();
    private bool _rotate = true; // false - left , true - right
    private bool _newrotate = false;
    private void Awake()
    {
        _goblininput = GetComponent<GoblinInput>();
        OnBerserk.AddListener(HandleBerserk);
    }

    private void HandleBerserk()
    {
        Rotate();
        Vector3 direction = (_goblininput.Player.transform.position - _goblininput.GoblinBody.transform.position).normalized;
        direction.y = 0;
        _goblininput.GoblinRigidbody.MovePosition(_goblininput.GoblinRigidbody.position + direction * Speed * Time.fixedDeltaTime);
    }
    private void Rotate()
    {
        if (_goblininput.GoblinBody.transform.position.x - _goblininput.Player.transform.position.x < 0f)
        {
            _newrotate = true;
            if(_rotate != _newrotate)
            {
                _rotate = _newrotate;
                GoblinRotate.OnRotateRight.Invoke();
            }

        }
        else
        {
            _newrotate = false;
            if (_rotate != _newrotate)
            {
                _rotate = _newrotate;
                GoblinRotate.OnRotateLeft.Invoke();
            }
        }
    }
}
