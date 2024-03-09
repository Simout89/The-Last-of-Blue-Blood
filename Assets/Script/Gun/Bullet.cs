using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _lifetime = 5;
    private ParticleSystem _particle;
    private void Start()
    {
        _particle = GetComponent<ParticleSystem>();
        StartCoroutine(Life());
    }
    private IEnumerator Life()
    {
        yield return new WaitForSeconds(_lifetime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if((other.tag == "Enemy") || (other.tag == "Map") || (other.tag == "Untagged"))
        {
            Destroy(gameObject);
        }
    }
}
