using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAnim : MonoBehaviour
{

    private Animator animator;


    private string currentState = IDLE;
    const string IDLE = "Armature|Idle";
    private void Awake()
    {
        animator = GetComponent<Animator>();
        DragonAttack.OnCastFireBall.AddListener(HandleCastFireBall);
        DragonIdle.OnBossIdle.AddListener(HandleBossIdle);
    }

    private void HandleBossIdle(bool arg0)
    {
        if (arg0)
        {
            animator.SetBool("Idle", true);
        }
        else
            animator.SetBool("Idle", false);
    }

    private void HandleCastFireBall()
    {
        animator.SetTrigger("MoveAttack");
    }
}
