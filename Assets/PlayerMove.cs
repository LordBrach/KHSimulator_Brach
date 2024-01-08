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
    [SerializeField] float _rotationSpeed;

    private Rigidbody _rBody;

    // Event pour les dev
    public event Action OnStartMove;
    public event Action OnStopMove;
    //public event Action OnUpdateMove;
    // Event pour les GD
    [SerializeField] UnityEvent _onEvent;
    [SerializeField] UnityEvent _onEventPost;

    public Vector2 JoystickDirection { get; private set; }
    Coroutine MovementRoutine { get; set; }

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
       //OnUpdateMove?.Invoke();
    }

    private void StopMove(InputAction.CallbackContext context)
    {
        OnStopMove?.Invoke();
    }

    private void StartMove(InputAction.CallbackContext context)
    {
        OnStartMove?.Invoke();
        MovementRoutine = StartCoroutine(PlayerMoveRoutine());
    }

    IEnumerator PlayerMoveRoutine()
    {
        while(true)
        {
            // TODO maybe change this to fix the "locked to axises" issue
            JoystickDirection = _move.action.ReadValue<Vector2>();
            Vector3 direction = new Vector3(JoystickDirection.x, 0, JoystickDirection.y);
            direction.Normalize();

            _rBody.velocity = direction * _speed;
            
            if(direction != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
            }

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
