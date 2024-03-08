using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunSpawnBullet : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform Anchor;
    [SerializeField] private Transform Muzzle;
    [SerializeField] private float BulletForce = 10f;
    public static UnityEvent OnSpawnBullet = new UnityEvent();

    private void Awake()
    {
        OnSpawnBullet.AddListener(HandleSpawnBullet);
    }
    private void HandleSpawnBullet()
    {
        GameObject bullet = Instantiate(BulletPrefab, Muzzle.position, Quaternion.identity);
        var direction = Muzzle.position - Anchor.position;
        bullet.GetComponent<Rigidbody>().AddForce(direction * BulletForce, ForceMode.VelocityChange);
    }
}
