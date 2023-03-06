using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PLayer : MonoBehaviour
{
    public int Health { get; private set; }

    public int MaxHealht { get; private set; }

    public UnityEvent HealthChanged;

    private void Start()
    {
        MaxHealht = 100;

        Health = MaxHealht;

        HealthChanged.Invoke();
    }

    public void TakeDamage(int damage)
    {
        if(damage > 0)
        {
            Health -= damage;
        }

        Health = Mathf.Clamp(Health, 0, 100);

        HealthChanged.Invoke();
    }

    public void TakeHeal(int heal)
    {
        if(heal > 0)
        {
            Health += heal;
        }

        Health = Mathf.Clamp(Health, 0, 100);

        HealthChanged.Invoke();
    }
}
