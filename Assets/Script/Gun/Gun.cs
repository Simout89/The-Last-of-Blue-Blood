using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    [SerializeField] private int _ammocount = 5;
    [SerializeField] private float _delay = 5;
    [SerializeField] private float _reloadtime = 5;
    [SerializeField] private float _forcebullet = 10f;
    [SerializeField] private Rigidbody _bullet;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private Transform _anchor;
    [SerializeField] private ParticleSystem _fire;

    private int _ammo;
    private bool _active = true;
    private bool _reload = false;

    public static UnityEvent<int> OnFire = new UnityEvent<int>();


    private void Awake()
    {
        _ammo = _ammocount;
        StartCoroutine(Delay());
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
        Rigidbody bullet = Instantiate(_bullet, _muzzle.position, Quaternion.identity);
        var direction = _muzzle.position - _anchor.position;
        bullet.AddForce(direction * _forcebullet, ForceMode.VelocityChange);
    }
    IEnumerator Shot()
    {
        _fire.Play();
        SpawnBullet();
        _ammo--;
        CheckAmmo();
        OnFire.Invoke(_ammo);

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
        OnFire.Invoke(_ammocount);
        _reload = false;
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.01f);
        OnFire.Invoke(_ammocount);
    }
}