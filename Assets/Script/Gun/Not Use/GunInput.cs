using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunInput : MonoBehaviour
{
    //[SerializeField] private int _ammocount = 5;
    //[SerializeField] private float _delay = 5;
    //[SerializeField] private float _reloadtime = 5;
    public bool Fire { get; private set; }
    public static UnityEvent OnFire = new UnityEvent();

    private void Update()
    {
        Fire = Input.GetButtonDown("HeightJump");
        if (Fire) OnFire.Invoke();
    }
}
