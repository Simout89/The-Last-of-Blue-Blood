using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _princesscount = 0;
    private void Start()
    {
        EventManager.Princess.AddListener(PrincessCollect);
        EventManager.Finish.AddListener(Finish);
    }
    private void PrincessCollect()
    {
        _princesscount++;
    }
    private void Finish()
    {
        Debug.Log(_princesscount);
    }
}
