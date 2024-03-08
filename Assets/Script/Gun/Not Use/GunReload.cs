using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunReload : MonoBehaviour
{
    GunFire gunfire;
    public static UnityEvent OnCheckAmmo = new UnityEvent();

    private void Awake()
    {
        gunfire = GetComponent<GunFire>();
        OnCheckAmmo.AddListener(HandleCheckAmmo);
    }
    private void HandleCheckAmmo()
    {
        if(gunfire._ammo <= 0)
        {

        }
    }
}
