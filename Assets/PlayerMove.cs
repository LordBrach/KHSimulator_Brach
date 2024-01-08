using Cinemachine;
using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] InputActionReference _move;
    [SerializeField] float _speed;

    private Rigidbody _rBody;

    // Event pour les dev
    public event Action OnStartMove;
    public event Action<int> OnHealthUpdate;

    // Event pour les GD
    [SerializeField] UnityEvent _onEvent;
    [SerializeField] UnityEvent _onEventPost;

    public Vector2 JoystickDirection { get; private set; }
    //Coroutine MovementRoutine { get; set; }

    private void Start()
    {
        _rBody = GetComponent<Rigidbody>();
        if (_rBody == null)
            Debug.LogError("Player Rigidbody is NULL");

        _move.action.actionMap.Enable();

        _move.action.started += StartMove;
        _move.action.performed += UpdateMove;
        _move.action.canceled += StopMove;
    }

    private void UpdateMove(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    private void StopMove(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    private void StartMove(InputAction.CallbackContext context)
    {
        OnStartMove?.Invoke();
        StartCoroutine(PlayerMoveRoutine());
    }

    IEnumerator PlayerMoveRoutine()
    {
        while(true)
        {
            JoystickDirection = _move.action.ReadValue<Vector2>();
            Vector3 direction = new Vector3(JoystickDirection.x, 0, JoystickDirection.y);

            _rBody.velocity = direction * _speed;
            yield return null;
        }
    }
    private void OnDestroy()
    {
        _move.action.actionMap.Disable();

        _move.action.started -= StartMove;
        _move.action.performed -= UpdateMove;
        _move.action.canceled -= StopMove;
    }

}
