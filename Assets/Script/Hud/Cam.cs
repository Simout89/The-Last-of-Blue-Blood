using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Cam : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    private Camera mainCamera;
    private float _camdistance = -10f;
    private float _y = 0;
    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        EventManager.Squat.AddListener(CamZoom);
    }
    private void LateUpdate()
    {
        var target = _target.position;
        target.z = _camdistance;
        target.y += _y;
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * _speed);
    }
    private void CamZoom(bool flag)
    {
        if(flag)
        {
            _y = 0.5f;
            Debug.Log(_y);
        }
        else
        {
            _y = 0f;
        }
    }
}
