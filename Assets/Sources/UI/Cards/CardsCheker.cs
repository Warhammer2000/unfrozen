using UnityEngine;
using UnityEngine.UI;

namespace UnfrozenTestProject
{
    public class CardsCheker : MonoBehaviour
    {
        private CardView cardView;
        private void Awake()
        {
            cardView = GetComponent<CardView>();    
        }
      
        public void Cheker(Image avatar)
        {
            if(avatar.sprite == null)
            {
                Destroy(gameObject);
            }
        }
    }
}
