using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Cam : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    private void LateUpdate()
    {
        var target = _target.position;
        target.z = -10;
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * _speed);
    }
}
