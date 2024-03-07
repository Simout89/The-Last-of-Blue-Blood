using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAI : MonoBehaviour
{
    [SerializeField] private float PlayerDistanceDetection = 1f;
    private bool _playernear = false;
    private GoblinInput _goblininput;

    private void Awake()
    {
        _goblininput = GetComponent<GoblinInput>();
        GoblinPlayerDetection.OnPlayerNear.AddListener(HandlePlayerNear);
    }
    private void HandlePlayerNear(bool flag)
    {
        _playernear = flag;
    }
    private void Update()
    {
        if (Vector3.Distance(_goblininput.GoblinBody.transform.position, _goblininput.Player.transform.position) < PlayerDistanceDetection)
        {
            GoblinBerserk.OnBerserk.Invoke();
        }else
        {
            GoblinPointWalk.OnPointWalk.Invoke();
        }
    }
}
