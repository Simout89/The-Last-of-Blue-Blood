using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField] private int Health = 5;
    [SerializeField] private Transform Mouth;
    [SerializeField] private float FireRate = 1f;
    [SerializeField] private GameObject FireBall;
    private GameObject player;
    private bool _shotcd = true;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        Fire();
    }
    private void FixedUpdate()
    {
        Rotate();
    }
    private void Fire()
    {
        if(_shotcd)
        {
            StartCoroutine(shotcd());
            SpawnFireBall();
        }
    }
    private void SpawnFireBall()
    {
        GameObject fireball = Instantiate(FireBall, Mouth.position, Quaternion.identity);
        var direction = player.transform.position - Mouth.position;
        fireball.GetComponent<Rigidbody>().AddForce(direction * 10f, ForceMode.VelocityChange);
    }
    IEnumerator shotcd()
    {
        _shotcd = false;
        yield return new WaitForSeconds(FireRate);
        _shotcd = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Health--;
            CheckHealt();
        }   
    }
    private void CheckHealt()
    {
        if (Health <= 0)
            Destroy(gameObject);
    }
    private void Rotate()
    {
        if (transform.position.x - player.transform.position.x < 0f)
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;
            currentRotation.y = 0f;
            transform.rotation = Quaternion.Euler(currentRotation);
        }else
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;
            currentRotation.y = 180f;
            transform.rotation = Quaternion.Euler(currentRotation);
        }
    }
}
