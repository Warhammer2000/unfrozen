using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnfrozenTestProject
{
    public class MapController : MonoBehaviour
    {
        [SerializeField] private List<MissionDescription> descriptions;

        private List<MissionButton> buttons;

        public Action<MissionDescription> OnChooseMission;

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
    }
}
