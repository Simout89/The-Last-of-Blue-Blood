using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoblinBerserk : MonoBehaviour
{
    [SerializeField] private float Speed = 1f;
    private GoblinInput _goblininput;
    public static UnityEvent OnBerserk = new UnityEvent();
    private void Awake()
    {
        _goblininput = GetComponent<GoblinInput>();
        OnBerserk.AddListener(HandleBerserk);
    }

    private void HandleBerserk()
    {
        GoblinBerserkRotate.OnBerserkRotate.Invoke();
        Vector3 direction = (_goblininput.Player.transform.position - _goblininput.GoblinBody.transform.position).normalized;
        //direction.y = 0;
        _goblininput.GoblinRigidbody.MovePosition(_goblininput.GoblinRigidbody.position + direction * Speed * Time.fixedDeltaTime);
    }
}
