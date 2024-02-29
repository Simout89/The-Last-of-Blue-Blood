using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessCore : MonoBehaviour
{
    private int _princesscount = 0;
    private void Start()
    {
        EventManager.Princess.AddListener(PrincessCollect);
        EventManager.Finish.AddListener(Finish);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

        }
    }
    private void PrincessCollect()
    {
        _princesscount++;
    }
    private void Finish()
    {

    }
}
