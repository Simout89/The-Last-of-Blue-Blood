using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
            EventManager.damageplayer();
        Destroy(gameObject);
    }
}
