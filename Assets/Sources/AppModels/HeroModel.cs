using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace UnfrozenTestProject
{
    [CreateAssetMenu(menuName = "Heroes/Create hero", fileName = "Hero")]
    public class HeroModel : ScriptableObject, IModel
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite avatar;
        [SerializeField] private string _id;
        public int score;

        public void IncreaseScrore(int score)
        {
            this.score += score;
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
        public Sprite Avatar
        {
            get => avatar;
            set
            {
                if (value != avatar)
                {
                    avatar = value;
                    PropertyChanged?.Invoke(nameof(Avatar), avatar);
                }
            }
        }

        public string Id => _id;

        public event Action<string, object> PropertyChanged;
    }
}
