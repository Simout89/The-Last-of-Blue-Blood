using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal {  get; private set; }
    public bool Jump { get; private set; }
    public bool HeightJump { get; private set; }
    public static UnityEvent OnJump = new UnityEvent();
    public static UnityEvent OnHeightJump = new UnityEvent();

    public static UnityEvent<bool> OnSquat = new UnityEvent<bool>();
    private void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Jump = Input.GetButtonDown("Jump");
        if(Jump && !HeightJump) OnJump.Invoke();
        HeightJump = Input.GetButtonDown("HeightJump");
        if (HeightJump && !Jump) OnHeightJump.Invoke();
        if(Input.GetButtonDown("Squat"))
            OnSquat.Invoke(true);
        if (Input.GetButtonUp("Squat"))
            OnSquat.Invoke(false);
    }
}
