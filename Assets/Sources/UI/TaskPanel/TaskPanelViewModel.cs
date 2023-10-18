using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UnfrozenTestProject
{
    public class TaskPanelViewModel : MonoBehaviour, IViewModel
    {
        private TaskPanelModel model;

        [SerializeField] private MapController mapController;
        [SerializeField] private TaskPanelView view;
        [SerializeField] private GameObject content;
        [SerializeField] private bool isMissionBar;
        public event Action<MissionDescription> OnDescriptionChange;

        private void Awake()
        {
            model = new TaskPanelModel();
            view.Initialize(this);
        }

        private void Start()
        {
            mapController.OnChooseMission += (descr) =>
            {
                model.MissionDescription = descr;
            };

            model.PropertyChanged += HandleModelPropertyChange;
        }

        private void HandleModelPropertyChange(string propertyName, object value)
        {
            if (propertyName == nameof(model.MissionDescription))
            {
                if (!isMissionBar)
                {
                    content.SetActive(true);
                    OnDescriptionChange?.Invoke(model.MissionDescription);
                }
                else
                {
                    OnDescriptionChange?.Invoke(model.MissionDescription);
                }
            }
        }
    }
}
