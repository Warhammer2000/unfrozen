using System;
using TMPro;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Profiling.HierarchyFrameDataView;

namespace UnfrozenTestProject
{
    public class TaskPanelView : MonoBehaviour, IView
    {
        [Header("Base_UI_Settings")]
        [SerializeField] private TextMeshProUGUI missionNameTMP;
        [SerializeField] private Image missionImage;
        [SerializeField] private TextMeshProUGUI missionDetailsTMP;
        [Space]
        [SerializeField] private TextMeshProUGUI missionHeroTMP;
        [SerializeField] private TextMeshProUGUI missionEnemyTMP;
        [Space]
        [SerializeField] private Button taskContextButton;

        [Header("Backend Settings")]
        [SerializeField] private TaskPanelViewModel viewmodel;
        [SerializeField] private bool isMissionCompletePanel;
        [SerializeField] private MissionDescription _description;

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
                _description = description;
                SetMissionDetails(description.details);
                SetMissionIcon(description.missionIcon);
                SetMissionName(description.title);
            }
        }
        private void FixedUpdate()
        {
            if (isMissionCompletePanel && _description != null)
            {
                SetMissionHeroName(_description.missionHeroName);
                SetMissionEnemyName(_description.missionEnemyName);
            }
        }
        private void SetMissionName(string value)
        {
            missionNameTMP.text = value;
        }
        private void SetMissionDetails(string value)
        {
            missionDetailsTMP.text = value;
        }
        private void SetMissionIcon(Sprite value)
        {
            missionImage.sprite = value;
        }
        private void SetMissionHeroName(string value)
        {
            missionHeroTMP.text = value;
        }
        private void SetMissionEnemyName(string value)
        {
            missionEnemyTMP.text = value;
        }
    }
}

