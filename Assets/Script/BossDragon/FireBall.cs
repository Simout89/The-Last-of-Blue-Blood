using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class FireBall : MonoBehaviour
{
    [SerializeField] private int _lifetime = 5;
    private void Start()
    {
        StartCoroutine(Life());
    }
    private IEnumerator Life()
    {
        yield return new WaitForSeconds(_lifetime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            PlayerHealth.DamageToPlayer.Invoke();
        if ( (other.tag != "Gun") && (other.tag != "Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
