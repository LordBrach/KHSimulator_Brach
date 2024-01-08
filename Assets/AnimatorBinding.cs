using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBinding : MonoBehaviour
{
    [SerializeField] PlayerMove _playerMove;
    [SerializeField] PlayerAttack _playerAttack;
    [SerializeField] EntityHealth _entityHealth;

    [SerializeField] Animator _playerAnim;


    private void OnDisable()
    {
        // unsubscribe to movement events
        _playerMove.OnStartMove -= StartMoveAnim;
        _playerMove.OnStopMove -= StopMoveAnim;
        // unsubscribe to attack events
        _playerAttack.OnStartAttack -= StartAttackAnim;
        _playerAttack.OnStopAttack -= StopAttackAnim;
        // unsubscribe to health events
        _entityHealth.OnGettingHit -= GetHitAnim;
    }


    private void OnEnable()
    {
        // subscribe to movement events
        _playerMove.OnStartMove += StartMoveAnim;
        _playerMove.OnStopMove += StopMoveAnim;
        // subscribe to attack events
        _playerAttack.OnStartAttack += StartAttackAnim;
        _playerAttack.OnStopAttack += StopAttackAnim;
        // subscribe to health events
        _entityHealth.OnGettingHit += GetHitAnim;

    }

    private void GetHitAnim(int obj)
    {
        _playerAnim.SetTrigger("GetHit");
    }

    // ATTACK EVENTS
    private void StopAttackAnim()
    {
        _playerAnim.ResetTrigger("Attack");
    }

    private void StartAttackAnim()
    {
        _playerAnim.SetBool("Walking", false);
        _playerAnim.SetTrigger("Attack");

    }

    // MOVEMENT EVENTS
    private void StartMoveAnim()
    {
        _playerAnim.ResetTrigger("Attack");
        _playerAnim.SetBool("Walking", true);
    }
    private void StopMoveAnim()
    {
        _playerAnim.SetBool("Walking", false);
    }


}
