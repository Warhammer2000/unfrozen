using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UnfrozenTestProject
{
    public class MapController : MonoBehaviour
    {
        [SerializeField] private List<MissionDescription> descriptions;

        [SerializeField] private List<MissionButton> buttons;

        public Action<MissionDescription> OnChooseMission;

        [SerializeField] private List<Button> buttononetwo;

        public Button[] buttonsToDisable;
        public float index = 0;
        private void Awake()
        {
            buttons = new List<MissionButton>(16);
            GetComponentsInChildren(buttons);
        }

        private void Start()
        {
            foreach (var button in buttons)
            {
                button.OnClick += HandleMissionButtonClick;
            }
        }

        private void HandleMissionButtonClick(float id)
        {
            var desription = descriptions.Find(x => x.id == id);
            OnChooseMission?.Invoke(desription);
        }
        public void CompleteMission()
        {
            if (index == 31 ) buttononetwo[0].interactable = false;
            else if (index == 32) buttononetwo[1].interactable = false;
            else buttonsToDisable[(int)index].interactable = false;
        }
        
    }
}
