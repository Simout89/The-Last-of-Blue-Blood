using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class DragonIdle : MonoBehaviour
{
    [SerializeField] private int MinionCountMin = 4;
    [SerializeField] private int MinionCountMax = 6;
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
        idlePoint = IdlePoint.position;
        OnBossIdle.AddListener(HandleBossIdle);
    }

    private void HandleBossIdle(bool arg0)
    {
        if (arg0)
        {
            idle = arg0;
            Body.transform.DOMove(idlePoint, Speed).SetEase(Ease.Linear).OnComplete(spawnMinion);
        }
        else
            PlayerHealth.HealthPlayer.Invoke();
    }
    private void spawnMinion()
    {
        StartCoroutine(SpawnMinion());
    }
    private IEnumerator SpawnMinion()
    {
        System.Random rnd = new System.Random();
        Minion = rnd.Next(MinionCountMin, MinionCountMax);
        while (Minion != 0)
        {
            Instantiate(MinionPrefab, MinionSpawns[rnd.Next(0, MinionSpawns.Length)].position, Quaternion.identity);
            Minion--;
            yield return new WaitForSeconds(MinionSpawnDelay);
        }
    }
}
