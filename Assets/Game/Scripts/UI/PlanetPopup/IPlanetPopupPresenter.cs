using System;
using Modules.Planets;
using UnityEngine;

namespace Game.UI
{
    public interface IPlanetPopupPresenter
    {
        public event Action OnStateChanged;
        public string Name { get; }
        public string Population { get; }
        public Sprite Icon { get; }
        public string Price { get; }
        public string Level { get; }
        public string Income { get; }

        public void ChangePlanet(IPlanet planet);
        public bool CanUpgrade();
        public void Upgrade();
    }
}