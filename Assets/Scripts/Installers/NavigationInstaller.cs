using UnityEngine;
using Zenject;

public class NavigationInstaller : MonoInstaller
{
    [SerializeField]
    public ScreensContainer screensContainer;
    
    [SerializeField]
    public RectTransform screensRootRectTransform;
    
    public override void InstallBindings()
    {
        Container.BindInstance(screensContainer);
        Container.BindInstance(screensRootRectTransform);
        Container.BindFactory<UnityEngine.Object, Screen, Screen.Factory>().FromFactory<PrefabFactory<Screen>>();
        Container.Bind<Navigation>().AsSingle();
        
        Container.Bind<ScreenAPresenter>().AsTransient();
    }
}