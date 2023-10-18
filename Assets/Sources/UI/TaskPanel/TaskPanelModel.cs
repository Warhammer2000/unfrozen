using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnfrozenTestProject
{
    public class TaskPanelModel : IModel
    {
        private MissionDescription missionDescription;

        public MissionDescription MissionDescription
        {
            get => missionDescription;
            set
            {
                if (value != missionDescription)
                {
                    missionDescription = value;
                    PropertyChanged?.Invoke(nameof(MissionDescription), missionDescription);
                }
            }
        }

        public event Action<string, object> PropertyChanged;
    }
}
