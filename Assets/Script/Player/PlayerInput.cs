using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    private bool _state = true;
    public float Horizontal {  get; private set; }
    public bool Jump { get; private set; }
    public bool HeightJump { get; private set; }
    public static UnityEvent OnJump = new UnityEvent();
    public static UnityEvent OnHeightJump = new UnityEvent();

    public static UnityEvent<bool> OnSquat = new UnityEvent<bool>();
    public static UnityEvent<bool> OnInputState = new UnityEvent<bool>();
    private void Awake()
    {
        OnInputState.AddListener(HandleInputState);
    }

    private void HandleInputState(bool arg0)
    {
        _state = arg0;
    }

    private void Update()
    {
        if(_state)
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
            Jump = Input.GetButtonDown("Jump");
            if (Jump && !HeightJump) OnJump.Invoke();
            HeightJump = Input.GetButtonDown("HeightJump");
            if (HeightJump && !Jump) OnHeightJump.Invoke();
            if (Input.GetButtonDown("Squat"))
                OnSquat.Invoke(true);
            if (Input.GetButtonUp("Squat"))
                OnSquat.Invoke(false);
        }else
        {
            Horizontal = 0;
        }
    }
}
