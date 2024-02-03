using UnityEngine;
using Zenject;

public class ScreenInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ScreenAPresenter>().AsSingle();
    }
}