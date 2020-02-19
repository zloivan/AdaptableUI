using System;
using UnityEngine;

[RequireComponent(typeof(Stats))]
public class Entity : MonoBehaviour
{
    public int CurrentHealth { get; private set; }
    [SerializeField] private Stats stats;

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        if (Debug.isDebugBuild) Debug.Log($"<color=purple>{this.gameObject} Current health : {CurrentHealth}</color>");
    }

    private void Start()
    {
        if (stats == null)
        {
            stats = GetComponent<Stats>();
        }

        CurrentHealth = stats.MaxHealth;
    }
}