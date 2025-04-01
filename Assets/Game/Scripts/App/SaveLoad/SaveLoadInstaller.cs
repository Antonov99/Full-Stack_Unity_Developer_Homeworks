using Zenject;

namespace App
{
    public class SaveLoadInstaller : Installer<SaveLoadInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameSaveLoader>().AsSingle().WithArguments().NonLazy();
        }
    }
}