using UnityEngine;
using Zenject;
namespace SCA
{
    // Dependency Injection
    // You can call static methods in this class to get object for your dependency injection.
    // This design pattern is known as "Service Locator Design Pattern"
    public class CounterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log($"Installing {this.name}");

            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<CountIncrementedSignal>();

            Container.Bind<ICountDBGateway>().To<CountDBGateway>().AsSingle();
            
            Container.Bind<CountUsecase>().AsSingle();

            Container.Bind<CountPresenter>().FromComponentInHierarchy().AsCached();

            Container.Bind<InstantiateScreenAUseCase>().AsSingle().NonLazy();
        }
    }
}