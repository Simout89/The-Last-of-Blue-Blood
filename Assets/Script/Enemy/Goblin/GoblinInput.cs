using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoblinInput : MonoBehaviour
{
    public Vector3 Point1 { get; private set; }
    public Vector3 Point2 { get; private set; }
    [SerializeField] public Transform Point;
    [SerializeField] public GameObject GoblinBody;
    [SerializeField] public Rigidbody GoblinRigidbody;
    [SerializeField] public GameObject Player;
    private void Awake()
    {
        Point1 = Point.position;
        Point2 = GoblinBody.transform.position;
    }
}
