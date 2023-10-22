using System;

namespace UnfrozenTestProject
{
    public class CardModel : IModel
    {
        public HeroModel heroModel { get; private set; }

        public HeroModel HeroModel
        {
            get => heroModel;
            set
            {
                if (value != heroModel)
                {
                    heroModel = value;
                    PropertyChanged?.Invoke(nameof(heroModel), heroModel);
                }
            }
        }

        public event Action<string, object> PropertyChanged;
    }
}