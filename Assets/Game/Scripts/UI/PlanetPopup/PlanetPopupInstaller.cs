using JetBrains.Annotations;
using Zenject;

namespace Game.UI
{
    [UsedImplicitly]
    public sealed class PlanetPopupInstaller : Installer<PlanetPopupView, PlanetPopupInstaller>
    {
        [Inject]
        private PlanetPopupView _popupView;
        
        public override void InstallBindings()
        {
            this.Container
                .Bind<PlanetPopupView>()
                .FromInstance(_popupView)
                .AsSingle()
                .NonLazy();

            this.Container
                .Bind<IPlanetPopupPresenter>()
                .To<PlanetPopupPresenter>()
                .AsSingle();

            this.Container
                .Bind<PlanetPopupShower>()
                .AsSingle();

        }
    }
}