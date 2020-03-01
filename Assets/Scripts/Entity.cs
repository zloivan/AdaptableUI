using System;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Stats))]
public class Entity : MonoBehaviour
{
    public int CurrentHealth { get; private set; }
    [FormerlySerializedAs("stats")] public Stats Stats;
    [SerializeField] private int initialHealth = 100;
    public int InitialHealth => initialHealth;
    public event Action<int> OnHealthChanged;
    
    
    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        if (Debug.isDebugBuild) Debug.Log($"<color=purple>{this.gameObject} Current health : {CurrentHealth}</color>");
    }

    private void Start()
    {
        if (Stats == null)
        {
            Stats = GetComponent<Stats>();
        }

        CurrentHealth = initialHealth;
    }
}