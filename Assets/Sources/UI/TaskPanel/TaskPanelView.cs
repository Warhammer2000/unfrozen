using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEditor.Android;
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
        [SerializeField] private ControllerService controller;
        [SerializeField] private TaskPanelViewModel viewmodel;


        private void Start()
        {
            viewmodel = GetComponent<TaskPanelViewModel>();
            SetMissionHero();


        }
        public void Initialize(IViewModel viewModel)
        {
            var vm = viewModel as TaskPanelViewModel;
            Debug.Log(vm);
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
        private void SetMissionHero()
        {
            if (viewmodel.isMissionBar)
            {
               // mssionHeroTMP.text = controller.cardViewModel.model.HeroModel.Name;
            }
            else return;
        }

    }
}

