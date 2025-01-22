using JetBrains.Annotations;
using Modules.UI;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.UI
{
    [UsedImplicitly]
    public class UiInstaller : MonoInstaller
    {
        [SerializeField]
        private PlanetView[] _planetViews;

        [SerializeField]
        private Transform _transform;

        [SerializeField]
        private ParticleAnimator _particleAnimator;
        
        [SerializeField]
        private MoneyView _moneyView;

        [FormerlySerializedAs("_popup")]
        [SerializeField]
        private PlanetPopupView _popupView;

        public override void InstallBindings()
        {
            PlanetInstaller.Install(Container, _planetViews, _transform, _particleAnimator);
            MoneyInstaller.Install(Container, _moneyView);
            PlanetPopupInstaller.Install(Container, _popupView);
        }
    }
}