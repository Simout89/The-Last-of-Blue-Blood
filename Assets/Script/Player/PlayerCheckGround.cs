using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerCheckGround : MonoBehaviour
{
    public static UnityEvent<bool> IsGround = new UnityEvent<bool>();
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.05f))
            IsGround.Invoke(true);
        else
            IsGround.Invoke(false);
    }
}
