using UnityEngine;
using UnityEngine.UI;

namespace UnfrozenTestProject
{
    public class ControllerService : MonoBehaviour
    {
       
        public CardViewModel cardViewModel { get; private set; }
        [SerializeField] private Button button;
        public bool isChoosen = false;

        private int index = 0;
        private void Start()
        {
            button = GetComponent<Button>();
            cardViewModel = GetComponent<CardViewModel>();
            button.onClick.AddListener(ChooseHero);
        }
        public void onButtonClicked() => index++;
        private void ChooseHero()
        {
            isChoosen = true;
        }
       
    }
}