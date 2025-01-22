using JetBrains.Annotations;
using Modules.Planets;
using Modules.UI;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    [UsedImplicitly]
    public class PlanetInstaller:Installer<PlanetView[], Transform, ParticleAnimator, PlanetInstaller>
    {
        [Inject]
        private PlanetView[] _planetViews;

        [Inject]
        private Transform _transform;

        [Inject]
        private ParticleAnimator _particleAnimator;
        
        public override void InstallBindings()
        {
            Container
                .BindFactory<Planet, PlanetView, PlanetPresenter, PlanetPresenter.Factory>()
                .AsSingle();

            Container.Bind<PlanetView[]>().FromInstance(_planetViews).AsSingle();
            Container.Bind<Transform>().FromInstance(_transform).AsSingle();
            Container.Bind<ParticleAnimator>().FromInstance(_particleAnimator).AsSingle();

            Container.BindInterfacesTo<PlanetsCatalogPresenter>().AsSingle();
        }
    }
}