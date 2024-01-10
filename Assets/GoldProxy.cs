using Codice.CM.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldProxy : MonoBehaviour
{
    [SerializeField] EntityGold entityGoldRef;
    public void ChangeGoldValue(int value)
    {
        entityGoldRef.ChangeGoldValue(value);
    }

}
