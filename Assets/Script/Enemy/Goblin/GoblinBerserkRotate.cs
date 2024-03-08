using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class GoblinBerserkRotate : MonoBehaviour
{
    private GoblinInput _goblininput;
    private bool _rotate = true; // false - left , true - right
    private bool _newrotate = false;
    public static UnityEvent OnBerserkRotate = new UnityEvent();

    private void Awake()
    {
        _goblininput = GetComponent<GoblinInput>();
        OnBerserkRotate.AddListener(HandleBerserkRotate);
    }
    private void HandleBerserkRotate()
    {
        if (_goblininput.GoblinBody.transform.position.x - _goblininput.Player.transform.position.x < 0f)
        {
            _newrotate = true;
            if (_rotate != _newrotate)
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
