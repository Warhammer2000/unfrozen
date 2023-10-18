using System;

namespace UnfrozenTestProject
{
    public class CardModel : IModel
    {
        private HeroModel heroModel;
        
        public HeroModel HeroModel
        {
            get => heroModel;
            set
            {
                if (value != heroModel)
                {
                    heroModel = value;
                    PropertyChanged?.Invoke("HeroModel", heroModel);
                }
            }
        }

        public event Action<string, object> PropertyChanged;
    }
}