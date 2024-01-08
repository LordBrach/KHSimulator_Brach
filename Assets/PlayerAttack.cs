using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputSettings;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] InputActionReference _attack;
    [SerializeField] int _dmg;

    // Event pour les dev
    public event Action OnStartAttack;
    public event Action OnStopAttack;

    // Event pour les GD
    [SerializeField] UnityEvent _onEvent;
    [SerializeField] UnityEvent _onEventPost;

    public Coroutine AttackRoutine { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        _attack.action.actionMap.Enable();

        _attack.action.started += startAttack;
        _attack.action.canceled += stopAttack;

    }

    private void OnDestroy()
    {
        _attack.action.actionMap.Disable();

        _attack.action.started -= startAttack;
        _attack.action.canceled -= stopAttack;
    }

    private void stopAttack(InputAction.CallbackContext context)
    {
        OnStopAttack?.Invoke();
    }

    private void startAttack(InputAction.CallbackContext context)
    {
        OnStartAttack?.Invoke();
        AttackRoutine = StartCoroutine(PlayerAttackRoutine());
    }

    IEnumerator PlayerAttackRoutine()
    {
        // find colliders in range, check for ennemy, call enemy health method
        yield return null;
    }
}
