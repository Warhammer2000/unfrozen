using System;
using UnityEngine;

namespace UnfrozenTestProject
{
    public class CardsCreator : MonoBehaviour
    {
        [SerializeField] private Transform cardsRoot;
        [SerializeField] private GameObject cardPrefab;

        public static Action onTouched;
        private void OnEnable()
        {
            onTouched += CreateNewCard;
        }
        private void OnDisable()
        {
            onTouched -= CreateNewCard;
        }
        public void CreateNewCard()
        {
            GameObject card = Instantiate(cardPrefab, cardsRoot);
            CardViewModel cardViewModel = card.GetComponent<CardViewModel>();
            cardViewModel.heroesProvider.GetHeroModel(default);
        }
    }
}
