using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IHealth
{
    bool IsDead {  get; }
    void TakeDamage(int val);
    void Heal(int val);
    bool CheckDeath();
}
