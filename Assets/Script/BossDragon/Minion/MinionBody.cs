using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBody : MonoBehaviour
{
    [SerializeField] private int Health = 1;
    [SerializeField] private GameObject Minion;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Health--;
            CheckHealth();
        }
    }
    private void CheckHealth()
    {
        if (Health <= 0)
            Destroy(Minion);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth.DamageToPlayer.Invoke();
        }
    }
}
