using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

namespace UnfrozenTestProject
{
    public class TaskPanelViewModel : MonoBehaviour, IViewModel
    {
        private TaskPanelModel _model;
        private Button _buttonForDisable;
        [SerializeField] private float idForModel;

        [SerializeField] private bool StartMission;
        [SerializeField] private MapController mapController;
        [SerializeField] private TaskPanelView view;
        [SerializeField] private GameObject content;
        [SerializeField] private GameObject completeTaskPanel;

        public event Action<MissionDescription> OnDescriptionChange;

        private void Awake()
        {
            _model = new TaskPanelModel();
            view.Initialize(this);
        }

        private void Start()
        {
            mapController.OnChooseMission += (descr) =>
            {
                _model.MissionDescription = descr;
            };

            _model.PropertyChanged += HandleModelPropertyChange;
            view.ContextButtonClick += HandleMissionContextButton;
        }

        private void HandleModelPropertyChange(string propertyName, object value)
        {
            if (propertyName == nameof(_model.MissionDescription))
            {
                content.SetActive(true);
                OnDescriptionChange?.Invoke(_model.MissionDescription);
            }
        }

        private void HandleMissionContextButton()
        {
            if (StartMission)
            {
                completeTaskPanel.SetActive(true);
                Debug.Log("Миссия начата! Прочитайте подробности");
            }
            else
            {
                completeTaskPanel.SetActive(false);
                content.SetActive(false);
                CardsCreator.onTouched?.Invoke();
                Debug.Log("Миссия успешно заверешена!");
                InteractableButtonService.GetTouched?.Invoke(_buttonForDisable);
                _buttonForDisable.interactable = false;
                CardModel.MissionCompleteScrore?.Invoke();
            }
        }
        public void ButtonGetterToDisable(Button _button)
        {
            _buttonForDisable = _button;
        }

    }
}
