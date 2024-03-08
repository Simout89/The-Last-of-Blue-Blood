using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSquat : MonoBehaviour
{
    [SerializeField] private GameObject body;
    private CapsuleCollider _capsule;
    private Rigidbody _rb;
    private void Awake()
    {
        _capsule = GetComponent<CapsuleCollider>();
        _rb = GetComponent<Rigidbody>();
        PlayerInput.OnSquat.AddListener(HandleSquat);
    }

    private void HandleSquat(bool flag)
    {
        if (flag)
        {
            _capsule.height = 1f;
            var center = _capsule.center;
            center.y -= 0.4f;
            _capsule.center = center;
            //body.transform.localScale = new Vector3(1f, 0.5f, 1f);
            Vector3 pos = transform.position;
            pos.y -= 0.409f;
            transform.position = pos;
        }else
        {
            _capsule.height = 2f;
            var center = _capsule.center;
            center.y += 0.4f;
            _capsule.center = center;
            //body.transform.localScale = new Vector3(1f, 1f, 1f);
            Vector3 pos = transform.position;
            pos.y += 0.409f;
            transform.position = pos;
        }
    }
}
