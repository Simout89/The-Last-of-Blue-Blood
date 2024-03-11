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
            PlayerInput.OnInputState.Invoke(false);
            OnFinish.Invoke();
            Destroy(gameObject);
        }
    }
}
