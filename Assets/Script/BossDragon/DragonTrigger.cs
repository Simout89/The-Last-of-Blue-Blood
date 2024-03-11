using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragonTrigger : MonoBehaviour
{
    public static UnityEvent<bool> OnBossFight = new UnityEvent<bool>();

    private Collider Trigger;
    private void Awake()
    {
        Trigger = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnBossFight.Invoke(true);
            Trigger.enabled = false;
        }
    }
}
