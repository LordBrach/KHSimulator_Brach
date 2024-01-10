using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthProxy : MonoBehaviour, IHealth
{
    [SerializeField] EntityHealth _entityHealthRef;

    public bool IsDead => throw new System.NotImplementedException();

    public void Heal(int val)
    {
        _entityHealthRef.Heal(val);
    }

    public void TakeDamage(int val)
    {
        _entityHealthRef.TakeDamage(val);
    }
    public bool CheckDeath()
    {
        return (_entityHealthRef.CheckDeath());
    }
}
