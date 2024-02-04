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
        Debug.Log($"Installing {this.name}");
        Container.BindInstance(screensContainer);
        Container.BindInstance(screensRootRectTransform);
        Container.BindFactory<UnityEngine.Object, Screen, Screen.Factory>().FromFactory<PrefabFactory<Screen>>();
        Container.Bind<Navigation>().AsSingle();
        BindPresenters();
    }

    private void BindPresenters()
    {
        var presenters = screensContainer.GetScreensPresenters();
        foreach (var presenterType in presenters) {
            if (presenterType == null) {
                continue;
            }
            Container.Bind(presenterType).AsSingle();
        }
    }
}