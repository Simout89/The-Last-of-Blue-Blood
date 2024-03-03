using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoblinPlayerDetection : MonoBehaviour
{

    [SerializeField] private float PlayerDistanceDetection = 1f;
    private GoblinInput _goblininput;

    public static UnityEvent<bool> OnPlayerNear = new UnityEvent<bool>();

    private void Awake()
    {
        _goblininput = GetComponent<GoblinInput>();
    }
    private void Update()
    {
        OnPlayerNear.Invoke(Vector3.Distance(_goblininput.GoblinBody.transform.position, _goblininput.Player.transform.position) < PlayerDistanceDetection);
    }
    //private bool _raycastcheck()
    //{
    //    var direction = _goblininput.Player.transform.position - _goblininput.GoblinBody.transform.position;
    //    RaycastHit hit;
    //    if (Physics.Raycast(_goblininput.GoblinBody.transform.position, direction, out hit, PlayerDistanceDetection))
    //    {
    //        if ((hit.collider.gameObject.tag == "Player") || (hit.collider.gameObject.tag == "Gun"))
    //            return true;
    //        else
    //            return false;
    //    }
    //    else
    //        return false;
    //}
}
