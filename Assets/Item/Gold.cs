using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

public class Gold : Item
{
    [SerializeField] int _value;
    private GoldProxy _proxy;

    public override void ItemEffect(GameObject go)
    {
        Debug.Log("GOLD");
        _proxy = go.GetComponent<GoldProxy>();
        if (_proxy != null)
        {
            _proxy.ChangeGoldValue(_value);
            
        }
    }
}
