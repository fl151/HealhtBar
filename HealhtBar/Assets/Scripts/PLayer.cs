using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(Button))]
public class Player : MonoBehaviour
{
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _healButton;

    public int Health { get; private set; }
    public int MaxHealht { get; private set; }

    public UnityEvent HealthChanged;

    private UnityAction _takeDamage;
    private UnityAction _takeHeal;

    private int _damage = 10;
    private int _heal = 10;

    private void Start()
    {
        MaxHealht = 100;
        Health = MaxHealht;

        _takeDamage += TakeDamage;
        _takeHeal += TakeHeal;

        _damageButton.onClick.AddListener(_takeDamage);
        _healButton.onClick.AddListener(_takeHeal);

        HealthChanged.Invoke();
    }

    private void TakeDamage()
    {
        if (_damage > 0)
        {
            Health -= _damage;
        }

        Health = Mathf.Clamp(Health, 0, MaxHealht);

        HealthChanged.Invoke();
    }

    private void TakeHeal()
    {
        if (_heal > 0)
        {
            Health += _heal;
        }

        Health = Mathf.Clamp(Health, 0, MaxHealht);

        HealthChanged.Invoke();
    }

}
