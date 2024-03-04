using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAntiStuck : MonoBehaviour
{
    private bool _gunstuck = false;
    private float _ypos = 1.568f;
    private void Update()
    {
        GunRests();
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag != "Bullet") && (other.tag != "Player") && (other.tag != "Enemy"))
        {
            _gunstuck = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if ((other.tag != "Bullet") && (other.tag != "Player") && (other.tag != "Enemy"))
        {
            _gunstuck = false;
        }
    }
    private void GunRests()
    {
        if (_gunstuck)
        {
            var pos = transform.localPosition;
            pos.y = 0f;
            transform.localPosition = Vector3.Lerp(transform.localPosition, pos, Time.deltaTime * 2f);
        }
        else
        {
            var pos = transform.localPosition;
            pos.y = _ypos;
            float distance = Vector3.Distance(transform.localPosition, pos);
            transform.localPosition = Vector3.Lerp(transform.localPosition, pos, Time.deltaTime * 1f * (distance / 2));
        }
    }
}
