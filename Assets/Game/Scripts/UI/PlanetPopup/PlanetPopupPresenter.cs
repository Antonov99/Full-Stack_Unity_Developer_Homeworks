using System;
using JetBrains.Annotations;
using Modules.Planets;
using UnityEngine;

namespace Game.UI
{
    [UsedImplicitly]
    public class PlanetPopupPresenter : IPlanetPopupPresenter
    {
        public event Action OnStateChanged;

        public string Name => _planet.Name;
        public string Population => _planet.Population.ToString();
        public Sprite Icon => _planet.GetIcon(_planet.IsUnlocked);
        public string Price => _planet.Price > 0 ? _planet.Price.ToString() : "Max";
        public string Level => $"{_planet.Level} / {_planet.MaxLevel}";
        public string Income => $"{_planet.MinuteIncome} / min";

        private IPlanet _planet;

        private readonly IMoneyAdapter _moneyAdapter;

        public PlanetPopupPresenter(IMoneyAdapter moneyAdapter)
        {
            _moneyAdapter = moneyAdapter;
        }

        public void ChangePlanet(IPlanet planet)
        {
            if (planet != _planet)
            {
                if (_planet != null)
                {
                    _planet.OnPopulationChanged -= _ => OnStateChanged?.Invoke();
                }

                _planet = planet;
                OnStateChanged?.Invoke();
                _planet.OnPopulationChanged += _ => OnStateChanged?.Invoke();
            }
        }

        public bool CanUpgrade()
        {
            return _moneyAdapter.IsEnough(_planet.Price);
        }

        public void Upgrade()
        {
            _planet.Upgrade();
            OnStateChanged?.Invoke();
        }
    }
}