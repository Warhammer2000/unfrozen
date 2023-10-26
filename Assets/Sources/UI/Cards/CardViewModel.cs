using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace UnfrozenTestProject
{
    [RequireComponent(typeof(CardView))]
    public class CardViewModel : MonoBehaviour, IViewModel
    {
        public CardModel model;
        private CardView cardView;
        public HeroesProvider heroesProvider;

        public float id = 0;

        public event Action<HeroModel> HeroModelChanged;

        private void Awake()
        {
            heroesProvider = FindObjectOfType<HeroesProvider>();
            id = heroesProvider.IdIncrease();
        }
        


        private void Start()
        {
            cardView = GetComponent<CardView>();
            cardView.Initialize(this);

            model = new CardModel();

            model.PropertyChanged += CardModelPropertyChangehandler;
            model.HeroModel = heroesProvider.GetHeroModel(id.ToString());

        }
       
        private void CardModelPropertyChangehandler(string prop, object _)
        {
            if (prop == nameof(model.HeroModel))
            {
                HeroModelChanged?.Invoke(model.HeroModel);

            }
        }
    }
}
