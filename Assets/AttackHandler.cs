using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{

    [SerializeField] PlayerAttack _playerAttack;
    [SerializeField] BoxCollider _boxColliderAttack;
    [SerializeField] float _duration = 0.2f;

    private void OnDisable()
    {
        // unsubscribe to attack events
        _playerAttack.OnStartAttack -= ActivateBox;
        //_playerAttack.OnStopAttack -= DisableBox;
    }
    private void OnEnable()
    {
        _boxColliderAttack.enabled = false;
        // subscribe to attack events
        _playerAttack.OnStartAttack += ActivateBox;
        //_playerAttack.OnStopAttack += DisableBox;
    }

    private void ActivateBox()
    {
        _boxColliderAttack.enabled = true;
        StartCoroutine(DisableBoxAfterDelay());

    }

    IEnumerator DisableBoxAfterDelay()
    {
        _boxColliderAttack.enabled = true;
        yield return new WaitForSeconds(_duration);
        _boxColliderAttack.enabled = false;
    }

    private void DisableBox()
    {
        //_boxColliderAttack.enabled = false;
    }
}
