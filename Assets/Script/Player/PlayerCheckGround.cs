using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerCheckGround : MonoBehaviour
{
    public static UnityEvent<bool> IsGround = new UnityEvent<bool>();
    [SerializeField] private float Raduis = 1;
    [SerializeField] private float MaxDistance = 1;
    private void Update()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, Raduis, transform.forward, out hit, MaxDistance))
        {
            IsGround.Invoke(true);
        }
        else
            IsGround.Invoke(false);
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawSphere(transform.position+ transform.forward * MaxDistance, Raduis);
    //}
}
