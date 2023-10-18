using System.Collections;
using System.Collections.Generic;
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

        public void Initialize(IViewModel viewModel)
        {
            var vm = viewModel as TaskPanelViewModel;
            vm.OnDescriptionChange += HandleDescriptionChanged;
        }

        private void HandleDescriptionChanged(MissionDescription description)
        {
            SetMissionDetails(description.details);
            SetMissionIcon(description.missionIcon);
            SetMissionName(description.title);
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
