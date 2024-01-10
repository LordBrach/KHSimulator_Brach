using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class HealthPotion : Item
{
    [SerializeField] int _healingValue;
    [SerializeField] int _healingOverTimeLength;
    private IHealth playerHealth;
    public override void ItemEffect(GameObject go)
    {
        Debug.Log("POTION HEAL");
        playerHealth = go.GetComponent<IHealth>();
        if(playerHealth != null)
        {
            if(_healingOverTimeLength > 0) 
            {
                // start heal over time coroutine
            } else
            {
                playerHealth.Heal(_healingValue);
            }
        }
    }
}
