using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class HealthPanel : Bindable<Entity>
{
    [SerializeField] private Image healthBar;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private GameObject panelRoot;

    private Entity boundEntity;

    private void OnDestroy()
    {
        if (boundEntity != null)
        {
            boundEntity.OnHealthChanged -= HealthChangedHandler;
        }
    }

    private void HealthChangedHandler(int currentHealth)
    {
        healthText.text = $"{currentHealth} HP";
        
        healthBar.fillAmount = (float) currentHealth / boundEntity.InitialHealth;
    }

    public override void Bind(Entity entity)
    {
        if (boundEntity != null)
        {
            boundEntity.OnHealthChanged -= HealthChangedHandler;
        }

        boundEntity = entity;

        if (boundEntity != null)
        {
            panelRoot.SetActive(true);
            boundEntity.OnHealthChanged += HealthChangedHandler;
            HealthChangedHandler(boundEntity.CurrentHealth);
        }
        else
        {
            panelRoot.SetActive(false);
        }
    }
}