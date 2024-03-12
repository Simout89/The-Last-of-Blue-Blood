using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MinionAI : MonoBehaviour
{
    [SerializeField] private float Speed = 5f;
    private GameObject Player;
    [SerializeField] private Rigidbody Rigidbody;
    [SerializeField] private GameObject Body;
    private bool Rotate = false;
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

        if (Body.transform.position.x - Player.transform.position.x < 0f)
        {
            if (Rotate) // лево
            {
                Body.transform.DORotate(new Vector3(0, 90f, 0), 0.5f);
                Rotate = !Rotate;
            }
        }
        else
        {
            if (!Rotate)
            {
                Body.transform.DORotate(new Vector3(0, -90f, 0), 0.5f);
                Rotate = !Rotate;
            }
        }
    }
}
