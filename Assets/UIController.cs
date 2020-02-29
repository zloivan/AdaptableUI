using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private StatsList statsList;
    [SerializeField] private HealthPanel healthPanel;

    private void Awake()
    {
        //subscribe to entity change event
        ClickSelectController.OnSelectedEntityChanged += OnSelectedEntityChangedHandler;

        //invoke handler right away, to setup some default value
        OnSelectedEntityChangedHandler(ClickSelectController.SelectedEntity);
    }

    private void OnDestroy()
    {
        ClickSelectController.OnSelectedEntityChanged -= OnSelectedEntityChangedHandler;
    }

    private void OnSelectedEntityChangedHandler(Entity entity)
    {
        if (statsList != null)
        {
            if (entity != null && entity.Stats != null)
            {
                statsList.Bind(entity.Stats);
            }
        }

        if (healthPanel != null)
        {
            if (entity != null)
            {
                healthPanel.Bind(entity);
            }
        }
    }

    private void OnValidate()
    {
        if (statsList == null)
        {
            statsList = GetComponentInChildren<StatsList>();
        }
    }
}