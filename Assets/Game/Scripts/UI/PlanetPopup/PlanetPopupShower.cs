using JetBrains.Annotations;
using Modules.Planets;

namespace Game.UI
{
    [UsedImplicitly]
    public sealed class PlanetPopupShower
    {
        private readonly IPlanetPopupPresenter _planetPresenter;
        private readonly PlanetPopupView _planetPopupView;

        public PlanetPopupShower(IPlanetPopupPresenter planetPresenter, PlanetPopupView planetPopupView)
        {
            _planetPresenter = planetPresenter;
            _planetPopupView = planetPopupView;
        }

        public void Show(IPlanet planet)
        {
            _planetPresenter.ChangePlanet(planet);
            _planetPopupView.Show();
        }
    }
}