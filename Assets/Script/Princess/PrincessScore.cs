using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class PrincessScore : MonoBehaviour
{
    public int PrincessCount { get; private set; }
    public int MaxPrincess { get; private set; }
    private GameObject[] princess;
    private void Awake()
    {
        princess = GameObject.FindGameObjectsWithTag("Princess");
        PrincessCount = 0;
        PrincessCollect.OnCollectPrincess.AddListener(HandlePrincessCollect);
        StartCoroutine(delay());
    }
    private IEnumerator delay()
    {
        yield return new WaitForSeconds(1);
        MaxPrincess = princess.Length;    }
    private void HandlePrincessCollect()
    {
        PrincessCount++;
    }
}
