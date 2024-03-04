using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PrincessCollect : MonoBehaviour
{
    public static UnityEvent OnCollectPrincess = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnCollectPrincess.Invoke();
            Destroy(gameObject);
        }
    }
}
