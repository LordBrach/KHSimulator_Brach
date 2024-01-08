using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] InputActionReference _heal;
    [SerializeField] InputActionReference _selfwound;

    // variables
    [SerializeField] bool _isPlayer = false;
    [SerializeField] int _maxHealth;
    public int CurrentHealth { get; private set; }

    // Event pour les dev
    //public event Action<int> OnHealthUpdate;
    // public event Func<int, bool> OnHealthUpdate; // Same as above, except the OnHealthUpdate function takes an int param and returns a bool

    public event Action<int> OnGettingHit;
    public event Action<int> OnGettingHealed;

    public event Action OnDeath;

    // Event pour les GD
    [SerializeField] UnityEvent _onHealEvent;
    [SerializeField] UnityEvent _onDmgEvent;

    private void Awake()
    {
        CurrentHealth = _maxHealth;
        if(_isPlayer)
        {
            _heal?.action.actionMap.Enable();
            _selfwound?.action.actionMap.Enable();

            _heal.action.started += SelfHeal;
            _selfwound.action.started += SelfWound;
        }

    }

    private void OnDisable()
    {
        if(_isPlayer)
        {
            _heal.action.actionMap.Disable();
            _selfwound.action.actionMap.Disable();

            _heal.action.started -= SelfHeal;
            _selfwound.action.started -= SelfWound;
        }
    }

    private void SelfWound(InputAction.CallbackContext context)
    {
        TakeDamage(5);
    }

    private void SelfHeal(InputAction.CallbackContext context)
    {
        Heal(5);
    }

    public void TakeDamage(int damage)
    {
        if(damage  < 0) { damage = 0; }

        _onDmgEvent.Invoke();
        CurrentHealth = CurrentHealth - damage;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            OnDeath?.Invoke();
        }
        else if (_isPlayer)
        {
            OnGettingHit?.Invoke(CurrentHealth);
        }
    }

    public void Heal(int value)
    {
        if (value < 0) { TakeDamage(value); }
        else
        {
            CurrentHealth = CurrentHealth + value;
            _onHealEvent.Invoke();
            if (CurrentHealth >= _maxHealth) 
            { 
                CurrentHealth = _maxHealth; 
            }
            if(_isPlayer)
            { 
                OnGettingHealed?.Invoke(CurrentHealth); 
            }
        }
    }
}
