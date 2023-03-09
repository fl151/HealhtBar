using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(Player))]
public class Healthbar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Slider _slider;
    private float _targetValue;
    private Coroutine _changingSliderValue;

    private void Awake()
    {
        _slider = GetComponent<Slider>();

        _player.HealthChanged += ChangeValue;
    }

    private void Start()
    {
        _changingSliderValue = StartCoroutine(ChangeSliderValue());
    }

    private void ChangeValue()
    {
        _targetValue = _player.Health / (float)_player.MaxHealht;

        if(_changingSliderValue != null)
        {
            StopCoroutine(_changingSliderValue);
        }

        StartCoroutine(ChangeSliderValue());
    }

    private IEnumerator ChangeSliderValue()
    {
        var delay = new WaitForEndOfFrame();

        while (_slider.value != _targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, Time.deltaTime);

            yield return delay;
        }
    }
}
