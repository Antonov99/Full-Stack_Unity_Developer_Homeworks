using UnityEngine;
using Zenject;

namespace App
{
    [CreateAssetMenu(
            fileName = "AppInstaller",
            menuName = "Zenject/new AppInstaller"
        )
    ]
    public class AppInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SaveLoadInstaller>().AsSingle().NonLazy();
        }
    }
}