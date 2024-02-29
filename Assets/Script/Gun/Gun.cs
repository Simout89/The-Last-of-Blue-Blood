using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private int _ammocount = 5;
    [SerializeField] private float _delay = 5;
    [SerializeField] private float _reloadtime = 5;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private Transform _anchor;
    [SerializeField] private ParticleSystem _fire;

    private int _ammo;
    private bool _active = true;
    private bool _reload = false;

    private void Start()
    {
        _ammo = _ammocount;
        EventManager.Shot(_ammo);
    }

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (_active & Input.GetKeyDown(KeyCode.Mouse0) & !_reload)
            StartCoroutine(Shot());
    }

    private void SpawnBullet()
    {
        GameObject bullet = Instantiate(_bullet, _muzzle.position, Quaternion.identity);
        var direction = _muzzle.position - _anchor.position;
        bullet.GetComponent<Rigidbody>().AddForce(direction * 10f, ForceMode.VelocityChange);
    }
    IEnumerator Shot()
    {
        _fire.Play();
        SpawnBullet();
        Debug.Log("Fire");
        _ammo--;
        CheckAmmo();
        EventManager.Shot(_ammo);

        _active = false;
        yield return new WaitForSeconds(_delay);
        _active = true;
    }

    private void CheckAmmo()
    {
        if (_ammo <= 0)
            StartCoroutine(Reload());
    }

    IEnumerator Reload()
    {
        Debug.Log("Reload");
        _reload = true;
        yield return new WaitForSeconds(_reloadtime);
        _ammo = _ammocount;
        EventManager.Shot(_ammocount);
        _reload = false;
    }
}