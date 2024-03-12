using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragonAttack : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform Mouth;
    [SerializeField] private Rigidbody _miniFireBall;
    [SerializeField] private Rigidbody _FireBall;
    [SerializeField] private float FireRate = 1f;
    [SerializeField] private float ForceProjectile = 5f;
    private int counter = 0;
    private bool _flyAttack = false;
    private bool _idleAttack = false;
    private bool live = true;

    public static UnityEvent OnCastFireBall = new UnityEvent();

    private void Awake()
    {
        DragonPatrol.OnBossPatrol.AddListener(HandleBossPatrol);
        DragonHealth.OnDeath.AddListener(HandleDeath);
    }

    private void HandleDeath()
    {
        _flyAttack = false;
    }

    private void HandleBossPatrol(bool arg0)
    {
        _flyAttack = arg0;
        StartCoroutine(Delay());
    }
    private IEnumerator DelayFlyAttack()
    {
        if(_flyAttack )
        {
            OnCastFireBall.Invoke();
            if (counter < 5)
            {
                counter++;
                Rigidbody bullet = Instantiate(_miniFireBall, Mouth.position, Quaternion.identity);
                var direction = Player.position - Mouth.position;
                Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
                bullet.transform.rotation = rotation;
                bullet.AddForce(direction * ForceProjectile, ForceMode.VelocityChange);
                yield return new WaitForSeconds(FireRate);
                StartCoroutine(DelayFlyAttack());
            }
            else
            {
                counter = 0;
                Rigidbody bullet = Instantiate(_FireBall, Mouth.position, Quaternion.identity);
                var direction = Player.position - Mouth.position;
                Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
                bullet.transform.rotation = rotation;
                bullet.AddForce(direction * (ForceProjectile), ForceMode.VelocityChange);
                yield return new WaitForSeconds(FireRate);
                StartCoroutine(DelayFlyAttack());
            }
        }
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(DelayFlyAttack());
    }
}
