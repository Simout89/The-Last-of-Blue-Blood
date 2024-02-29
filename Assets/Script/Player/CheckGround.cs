using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        EventManager.isGround(true);
    }
    private void OnTriggerExit(Collider other)
    {
        EventManager.isGround(false);
    }
}
