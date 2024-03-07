using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    public static UnityEvent OnFinish = new UnityEvent();
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnFinish.Invoke();
            Destroy(gameObject);
        }
    }
}
