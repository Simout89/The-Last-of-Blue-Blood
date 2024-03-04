using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    PrincessScore princessScore;
    private void Awake()
    {
        princessScore = GetComponent<PrincessScore>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log(princessScore.PrincessCount);
        }
    }
}
