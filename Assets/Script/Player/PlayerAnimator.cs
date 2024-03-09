using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerInput playerinput;
    [SerializeField] private Animator _animator;
    private string currentState = IDLE;
    private bool _issquad = false;
    private bool _isattacking = false;
    private bool _isjumping = false;
    private bool _isheightjumpdelay = false;
    const string IDLE = "Armature|Idle";
    const string SQUAD = "Squad";
    const string SQUAD_RUN = "Armature|Sit Down_Run";
    const string RUN = "Armature|Run";
    const string ATTACK = "Armature|Attack";
    const string ATTACKANDRUN = "Armature|Attack and runj";
    const string JUMP = "Armature|Junp_";
    private void Awake()
    {
        playerinput = GetComponent<PlayerInput>();
        PlayerInput.OnSquat.AddListener(HandleSquat);
        Gun.OnFireSound.AddListener(HandleFire);
        PlayerInput.OnHeightJump.AddListener(HandleJump);
        HudHightJumpDelayText.OnHeightJumpDelayState.AddListener(HandleHeightJumpDelayState);

    }

    private void HandleHeightJumpDelayState(bool flag)
    {
        _isheightjumpdelay = flag;
    }

    private void HandleFire()
    {
        _isattacking = true;
        if (playerinput.Horizontal != 0)
        {
            ChangeAnimationState(ATTACKANDRUN);
        }
        else
        {
            ChangeAnimationState(ATTACK);
        }
        Invoke("AttackComplete", 0.5f);
    }

    private void HandleJump()
    {
        if(!_isheightjumpdelay)
        {
            _isjumping = true;
            ChangeAnimationState(JUMP);
            Invoke("JumpComplete", 0.7f);
        }
    }

    private void Update()
    {
        if (_issquad)
        {
            if (playerinput.Horizontal == 0)
                ChangeAnimationState(SQUAD);
            else
                ChangeAnimationState(SQUAD_RUN);
        }
        else if (playerinput.Horizontal != 0 && !_isattacking && !_isjumping)
            ChangeAnimationState(RUN);
        else if ((playerinput.Horizontal == 0) && !_isattacking && !_isjumping)
            ChangeAnimationState(IDLE);
    }
    private void ChangeAnimationState(string newState)
    {
        if(currentState == newState) return;
        _animator.Play(newState);
        currentState = newState;
    }
    private void HandleSquat(bool flag)
    {
        _issquad = flag;
    }
    private void AttackComplete()
    {
        _isattacking = false;
    }
    private void JumpComplete()
    {
        _isjumping = false;
    }
}
