using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignTrigger : MonoBehaviour
{
    [SerializeField] private string Text;
    private Collider SignCollider;
    private void Awake()
    {
        SignCollider = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SignCollider.enabled = false;
            TextMenuManager.OnTextMenu.Invoke(Text);
        }
    }
}
