using System;
using System.Collections;
using System.Collections.Generic;
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

        public int id;

        public event Action<HeroModel> HeroModelChanged;

        private void Awake()
        {
            model = new CardModel();

            
            heroesProvider = FindObjectOfType<HeroesProvider>();
            model.PropertyChanged += CardModelPropertyChangehandler;
            model.HeroModel = heroesProvider.GetHeroModel("0");

            cardView = GetComponent<CardView>();
            cardView.Initialize(this);
        }
        private void Start()
        {
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
