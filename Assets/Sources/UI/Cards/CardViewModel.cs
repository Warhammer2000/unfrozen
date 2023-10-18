using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnfrozenTestProject
{
    [RequireComponent(typeof(CardView))]
    public class CardViewModel : MonoBehaviour
    {
        [SerializeField] private CardModel model;
        private CardView cardView;

        public event Action<string> HeroNameChanged;

        private void Awake()
        {
            Debug.Log(HeroNameChanged);
            model = new CardModel();
            cardView = GetComponent<CardView>();

            model.HeroModel.PropertyChanged += HeroModelChangeHandler;
        }

        private void HeroModelChangeHandler(string property, object value)
        {
            if (property == nameof(model.HeroModel.Name))
            {
                HeroNameChanged?.Invoke((string)value);
            }

        }
    }
}
