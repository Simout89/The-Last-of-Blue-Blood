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
    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        EventManager.Squat.AddListener(CamZoom);
    }
    private void LateUpdate()
    {
        var target = _target.position;
        target.z = -10f;
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * _speed);
    }
    private void CamZoom(bool flag)
    {
        if(flag)
        {
            mainCamera.fieldOfView = 40;
        }
        else
        {
            mainCamera.fieldOfView = 60;
        }
    }
}
