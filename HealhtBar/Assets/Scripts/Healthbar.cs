using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private Slider _slider;
    private PLayer _player;

    private float _targetValue;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _player = FindObjectOfType<PLayer>();

        _player.HealthChanged.AddListener(ChangeValue);
    }

    private void Update()
    {
        if (_slider.value != _targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, Time.deltaTime);
        }
    }

    private void ChangeValue()
    {
        _targetValue = _player.Health / (float)_player.MaxHealht;
    }
}
