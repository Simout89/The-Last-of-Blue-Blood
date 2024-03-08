using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBody : MonoBehaviour
{
    [SerializeField] private int Health = 5;
    [SerializeField] private GameObject Goblin;
    private bool _playercontact = false;
    public bool getdamage = false;
    public bool _damagedelay = true;
    private void FixedUpdate()
    {
        DamagePlayer();
    }
    private void DamagePlayer()
    {
        if (_playercontact && _damagedelay)
        {
            StartCoroutine(damageplayer());
        }
    }
    IEnumerator damageplayer()
    {
        _damagedelay = false;
        PlayerHealth.DamageToPlayer.Invoke();
        yield return new WaitForSeconds(0.5f);
        _damagedelay = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _playercontact = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _playercontact = false;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Health--;
            CheckHealt();
            getdamage = true;
        }
    }
    private void CheckHealt()
    {
        if (Health <= 0)
            Destroy(Goblin);
    }
}
