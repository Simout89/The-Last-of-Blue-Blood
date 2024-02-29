using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _lifetime = 5;
    private ParticleSystem _particle;
    void Start()
    {
        _particle = GetComponent<ParticleSystem>();
        StartCoroutine(Life());
    }
    IEnumerator Life()
    {
        yield return new WaitForSeconds(_lifetime);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        _particle.Play();
        Destroy(gameObject);
    }    
}
