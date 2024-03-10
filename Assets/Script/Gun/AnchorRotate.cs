using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Pistol : MonoBehaviour
{
    [SerializeField] private GameObject _crosshair;

    private bool _state = true;
    private void Update()
    {
        PlayerInput.OnInputState.AddListener(HandleInputState);
        RotateAnchor();
    }

    private void HandleInputState(bool arg0)
    {
        _state = arg0;
    }

    private void RotateAnchor()
    {
        if(_state)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 7;
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 direction = cursorPosition - transform.position;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = rotation;
        }
    }
}
