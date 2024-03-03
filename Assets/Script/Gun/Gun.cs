using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

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
    private bool _gunstuck = false;
    private float _ypos = 1.568f;

    private void Start()
    {
        _ammo = _ammocount;
        EventManager.Shot(_ammo);
    }

    private void Update()
    {
        Fire();
    }
    private void LateUpdate()
    {
        GunRests();
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
        _reload = true;
        yield return new WaitForSeconds(_reloadtime);
        _ammo = _ammocount;
        EventManager.Shot(_ammocount);
        _reload = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag != "Bullet") && (other.tag != "Player"))
            _gunstuck = true;
    }
    private void OnTriggerExit(Collider other)
    {
       if((other.tag != "Bullet") && (other.tag != "Player"))
            _gunstuck = false;
    }

    private void GunRests()
    {
        if ( _gunstuck )
        {
            var pos = transform.localPosition;
            pos.y-=2f;
            transform.localPosition = Vector3.Lerp(transform.localPosition, pos, Time.deltaTime * 2f);
        }
        else
        {
            var pos = transform.localPosition;
            pos.y = _ypos;
            transform.localPosition = Vector3.Lerp(transform.localPosition, pos, Time.deltaTime * 1f);
        }
    }
}