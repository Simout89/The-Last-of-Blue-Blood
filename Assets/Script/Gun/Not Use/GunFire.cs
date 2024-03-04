using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    [SerializeField] private int AmmoCount = 5;
    [SerializeField] private float Delay = 5f;
    public int _ammo { get; set; }
    private bool _active = true;


    private void Awake()
    {
        _ammo = AmmoCount;
        GunInput.OnFire.AddListener(HandleFire);
    }
    private void HandleFire()
    {
        if (_active & Input.GetKeyDown(KeyCode.Mouse0) /*& !_reload*/)
            StartCoroutine(Shot());
    }
    IEnumerator Shot()
    {
        //_fire.Play();
        GunSpawnBullet.OnSpawnBullet.Invoke();
        _ammo--;
        GunReload.OnCheckAmmo.Invoke();
        EventManager.Shot(_ammo);

        _active = false;
        yield return new WaitForSeconds(Delay);
        _active = true;
    }
}
