using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] EntityGold _playerGold;
    // Start is called before the first frame update
    void Start()
    {
        _playerGold.OnGoldChange += _playerGold_OnGoldChange;
        _text.text = $"{_playerGold.CurrentGold}";
    }

    private void _playerGold_OnGoldChange()
    {
        _text.text = $"{_playerGold.CurrentGold}G";
    }
}
