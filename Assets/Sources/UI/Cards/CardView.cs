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

        private CardViewModel cardViewModel;

        public void Initialize(IViewModel viewModel)
        {
            if (!(viewModel is CardViewModel))
            {
                throw new ArgumentException("Invalid viewModel type");
            }

            cardViewModel = viewModel as CardViewModel;

            cardViewModel.HeroNameChanged += HeroModelNameChangeHandler;
        }

        private void HeroModelNameChangeHandler(string value)
        {
            heroNameTMP.text = value;
        }
    }
}
