using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnfrozenTestProject
{
    public class HeroesProvider : MonoBehaviour
    {
        public List<HeroModel> models;
        public float id; 
        public HeroModel GetHeroModel(string id)
        {
            return models.Find(x => x.Id == id);
        }
        public void GetId(float _id)
        {
            id = _id;
        }
        public float IdIncrease()
        {
           return id;
        }
    }
}
