using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnfrozenTestProject
{
    public class HeroModel : IModel
    {
        private string _name;
        private int _score;
        private string _avatarURL;

        public HeroModel(string name, int score, string avatarURL)
        {
            _name = name;
            _score = score;
            _avatarURL = avatarURL;
        }
        public string Name
        {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    PropertyChanged?.Invoke(nameof(Name), _name);
                }
            }
        }
        public int Score
        {
            get => _score;
            set
            {
                if (value != Score)
                {
                    _score = value;
                    PropertyChanged?.Invoke(nameof(Score), _score);
                }
            }
        }
        public string AvatarURL
        {
            get => _avatarURL;
            set
            {
                if (value != _avatarURL)
                {
                    _avatarURL = value;
                    PropertyChanged?.Invoke(nameof(AvatarURL), _avatarURL);
                }
            }
        }

        public event Action<string, object> PropertyChanged;
    }
}
