using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            EventManager.PrincessCollect();
            Destroy(gameObject);
        }
    }
}
