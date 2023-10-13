using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnfrozenTestProject
{
    public class HeroModel : IModel
    {
        private string name;
        private int score;
        private string avatarURL;

        public string Name
        {
            get => name;
            set
            {
                if (value != name)
                {
                    name = value;
                    PropertyChanged?.Invoke(nameof(Name), name);
                }
            }
        }
        public int Score
        {
            get => score;
            set
            {
                if (value != Score)
                {
                    score = value;
                    PropertyChanged?.Invoke(nameof(Score), score);
                }
            }
        }
        public string AvatarURL
        {
            get => avatarURL;
            set
            {
                if (value != avatarURL)
                {
                    avatarURL = value;
                    PropertyChanged?.Invoke(nameof(AvatarURL), avatarURL);
                }
            }
        }

        public event Action<string, object> PropertyChanged;
    }
}
