using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UnfrozenTestProject
{
    public class TaskPanelView : MonoBehaviour, IView
    {
        [SerializeField] private TextMeshProUGUI missionNameTMP;
        [SerializeField] private Image missionImage;
        [SerializeField] private TextMeshProUGUI mssionDetailsTMP;
        [SerializeField] private TextMeshProUGUI mssionHeroTMP;
        [SerializeField] private TaskPanelViewModel viewmodel;
        [SerializeField] private Button taskContextButton;

        public event Action ContextButtonClick;

        public void Initialize(IViewModel viewModel)
        {
            viewmodel = viewModel as TaskPanelViewModel;
            viewmodel.OnDescriptionChange += HandleDescriptionChanged;

            if (taskContextButton != null) taskContextButton.onClick.AddListener(() => ContextButtonClick?.Invoke());
            else Debug.Log(taskContextButton);
        }

        private void HandleDescriptionChanged(MissionDescription description)
        {
            if (description != null)
            {
                SetMissionDetails(description.details);
                SetMissionIcon(description.missionIcon);
                SetMissionName(description.title);
            }
        }

        private void SetMissionName(string value)
        {
            missionNameTMP.text = value;
        }

        private void SetMissionDetails(string value)
        {
            mssionDetailsTMP.text = value;
        }

        private void SetMissionIcon(Sprite value)
        {
            missionImage.sprite = value;
        }
    }
}

