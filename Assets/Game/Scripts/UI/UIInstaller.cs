using Zenject;

namespace Game.Gameplay
{
    //Don't modify
    public sealed class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ControlsView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<ControlsPresenter>().AsSingle();
        }
    }
}