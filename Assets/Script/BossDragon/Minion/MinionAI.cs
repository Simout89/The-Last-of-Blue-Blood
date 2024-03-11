using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAI : MonoBehaviour
{
    [SerializeField] private float Speed = 5f;
    private GameObject Player;
    [SerializeField] private Rigidbody Rigidbody;
    [SerializeField] private GameObject Body;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        Vector3 direction = (Player.transform.position - Body.transform.position).normalized;
        if (direction.y > 0.1f)
            direction.y = 0.1f;
        Rigidbody.MovePosition(Rigidbody.position + direction * Time.deltaTime * Speed);
    }
}
