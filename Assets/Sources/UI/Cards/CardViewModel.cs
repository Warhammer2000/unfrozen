using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

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

        private Button button;
        public bool isChosen = false;
        private void Awake()
        {
            heroesProvider = FindObjectOfType<HeroesProvider>();
            button = GetComponent<Button>();
            id = heroesProvider.IdIncrease();
            button.onClick.AddListener(SwitchBoolean);
        }


        private void SwitchBoolean()
        {
            CardViewModel[] allButtons = FindObjectsOfType<CardViewModel>();

            foreach (CardViewModel button in allButtons)
            {
                button.isChosen = false;
            }

            isChosen = true;
        }
        private void Start()
        {
            cardView = GetComponent<CardView>();
            cardView.Initialize(this);

            model = new CardModel();

            model.PropertyChanged += CardModelPropertyChangehandler;
            model.HeroModel = heroesProvider.GetHeroModel(id.ToString());
            CardModel.MissionCompleteScrore += CardModelScroreChangeHandler;
        }

        private void CardModelPropertyChangehandler(string prop, object _)
        {
            if (prop == nameof(model.HeroModel))
            {
                HeroModelChanged?.Invoke(model.HeroModel);
            }
        }
        private void CardModelScroreChangeHandler()
        {
            if (isChosen)
            {
                model.heroModel.Score += 5;
            }
        }

    }
}
