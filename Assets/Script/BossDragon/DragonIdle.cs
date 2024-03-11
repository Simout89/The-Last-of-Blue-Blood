using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class DragonIdle : MonoBehaviour
{
    [SerializeField] private int MinionCount = 4;
    private int Minion;
    [SerializeField] private float MinionSpawnDelay = 1;
    [SerializeField] private float Speed = 5;
    [SerializeField] private GameObject Body;
    [SerializeField] private Transform IdlePoint;
    [SerializeField] private Transform[] MinionSpawns;
    [SerializeField] private GameObject MinionPrefab;
    private Vector3 idlePoint;
    public static UnityEvent<bool> OnBossIdle = new UnityEvent<bool>();
    private bool idle = false;

    private void Awake()
    {
        Minion = MinionCount;
        idlePoint = IdlePoint.position;
        OnBossIdle.AddListener(HandleBossIdle);
    }

    private void HandleBossIdle(bool arg0)
    {
        if(arg0)
        {
            idle = arg0;
            Body.transform.DOMove(idlePoint, Speed).SetEase(Ease.Linear).OnComplete(spawnMinion);
        }
    }
    private void spawnMinion()
    {
        StartCoroutine(SpawnMinion());
    }
    private IEnumerator SpawnMinion()
    {
        while(Minion != 0)
        {
            for (int i = 0; i < MinionSpawns.Length; i++)
            {
                Instantiate(MinionPrefab, MinionSpawns[i].position, Quaternion.identity);
                Minion--;
                yield return new WaitForSeconds(MinionSpawnDelay);
                if (MinionCount == 0)
                    break;
            }
        }
        Minion = MinionCount;
    }
}
