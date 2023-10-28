using System;
using System.Collections;
using System.Collections.Generic;
using UnfrozenTestProject;
using UnityEngine;
using UnityEngine.UI;

namespace UnfrozenTestProject
{
    public class MissionButton : MonoBehaviour
    {
        [SerializeField] private float Id;
        private Button missionButton;

        public Action<float> OnClick;
        public HeroesProvider heroprovider;
        public TaskPanelViewModel taskpanel;
        private void Start()
        {
            missionButton = GetComponent<Button>();
            missionButton.onClick.AddListener(TaskButtonClickHandler);
            heroprovider = FindAnyObjectByType<HeroesProvider>();
        }

        public void TaskButtonClickHandler()
        {
            OnClick?.Invoke(Id);
            heroprovider.GetId(Id);
            taskpanel.ButtonGetterToDisable(missionButton);
        }
    }
}
