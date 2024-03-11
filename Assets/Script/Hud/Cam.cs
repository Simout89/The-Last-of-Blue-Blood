using System;
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
    private bool bossfight = false;
    private void Start()
    {
        DragonTrigger.OnBossFight.AddListener(HandleStartFight);
        mainCamera = GetComponent<Camera>();
    }

    private void HandleStartFight(bool arg)
    {
        bossfight = arg;
    }

    private void LateUpdate()
    {
        var target = _target.position;
        if (bossfight)
        {
            target.z = -10;
            target.y += 2;
        }
        else
            target.z = -7;
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * _speed);
    }
}
