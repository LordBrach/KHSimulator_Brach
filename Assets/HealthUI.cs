using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    [SerializeField] Slider _slider;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] EntityHealth _playerHealth;

    int CachedMaxHealth { get; set; }

    private void Start()
    {
        _playerHealth.OnGettingHealed += UpdateSlider;
        _playerHealth.OnGettingHit += UpdateSlider;
        CachedMaxHealth = _playerHealth._CurrentHealth;
        _slider.value = _playerHealth._CurrentHealth;
        _text.text = $"{CachedMaxHealth} / {CachedMaxHealth}";

    }

    void UpdateSlider(int newHealthValue)
    {
        _slider.value = newHealthValue;
        _text.text = $"{newHealthValue} / {CachedMaxHealth}";
    }

}
