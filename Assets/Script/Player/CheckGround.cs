using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static CheckGround Instance;

    public bool isground = false;

    void Start()
    {
        isground = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        EventManager.isGround(true);
    }
    private void OnTriggerExit(Collider other)
    {
        EventManager.isGround(false);
    }
}
