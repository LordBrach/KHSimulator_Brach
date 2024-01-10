using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntityGold : MonoBehaviour
{
    private int currentGold = 0;
    public int CurrentGold { get => currentGold; set => currentGold = value; }

    public event Action OnGoldChange;

    [SerializeField] UnityEvent _onGainGoldEvent;
    [SerializeField] UnityEvent _onLoseGoldEvent;
    // Update is called once per frame
    void Update()
    {
        // check collision with item or if enemy killed or something
        ChangeGoldValue(1);
    }

    void ChangeGoldValue(int value)
    {
        if(value > 0)
        {
            CurrentGold += value;
            _onGainGoldEvent.Invoke();
        } else if(value < 0)
        {
            CurrentGold -= value;
            if(CurrentGold < 0) { CurrentGold = 0; } // Dont want to go in the negatives now do we
            _onLoseGoldEvent.Invoke();
        }
        OnGoldChange.Invoke();
    }
}
