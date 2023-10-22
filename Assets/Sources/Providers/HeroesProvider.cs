using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnfrozenTestProject
{
    public class HeroesProvider : MonoBehaviour
    {
        public List<HeroModel> models;

        private void Awake()
        {
            //HeroModel[] hero = Resources.LoadAll<HeroModel>("Configs/Heroes");
           // models = new List<HeroModel>(hero);
        }
        public HeroModel GetHeroModel(string id)
        {
            return models.Find(x => x.Id == id);
        }
        public HeroModel GetHero(HeroModel model)
        {
            return model;
        }
    }
}
