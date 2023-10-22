using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

namespace UnfrozenTestProject
{
    public class CardView : MonoBehaviour, IView
    {
        [SerializeField] private TextMeshProUGUI scoreTMP;
        [SerializeField] private TextMeshProUGUI heroNameTMP;
        [SerializeField] private Image heroAvatarImage;

        [SerializeField] private CardViewModel cardViewModel;
        [SerializeField] private HeroModel currentHeroModel;

        public void Initialize(IViewModel viewModel)
        {
            if (!(viewModel is CardViewModel))
            {
                throw new ArgumentException("Invalid viewModel type");
            }

            HeroModelNameChangeHandler(currentHeroModel);
            cardViewModel = viewModel as CardViewModel;

            cardViewModel.HeroModelChanged += HeroModelNameChangeHandler;
        }

        private void HeroModelNameChangeHandler(HeroModel model)
        {
            if (currentHeroModel != null)
            {
                currentHeroModel.PropertyChanged -= HandleHeroModelPropertyChange;
            }

            currentHeroModel = model;
            currentHeroModel.PropertyChanged += HandleHeroModelPropertyChange;

            Repaint();
        }

        public void Repaint()
        {
            if (currentHeroModel == null)
            {
                return;
            }

            HeroNameChangeHandler(currentHeroModel.Name);
            HeroScoreChangeHandler(currentHeroModel.Score);
            HeroAvaraImageChangeHandler(currentHeroModel.Avatar);
        }

        private void HandleHeroModelPropertyChange(string prop, object _)
        {
            switch (prop)
            {
                case nameof(currentHeroModel.Name):
                    HeroNameChangeHandler(currentHeroModel.Name);
                    break;

                case nameof(currentHeroModel.Avatar):
                    HeroAvaraImageChangeHandler(currentHeroModel.Avatar);
                    break;

                case nameof(currentHeroModel.Score):
                    HeroScoreChangeHandler(currentHeroModel.Score);
                    break;
            }
        }

        private void HeroNameChangeHandler(string name)
        {
            heroNameTMP.text = name;
        }

        private void HeroScoreChangeHandler(int score)
        {
            scoreTMP.text = score.ToString();
        }

        private void HeroAvaraImageChangeHandler(Sprite avatar)
        {
            heroAvatarImage.sprite = avatar;
        }
    }
}
