using UnityEngine;
using Zenject;

public class NavigationInstaller : MonoInstaller
{
	[SerializeField]
	private ScreensContainer screensContainer;

	[SerializeField]
	private RectTransform screensRootRectTransform;

	public override void InstallBindings()
	{
		Debug.Log($"Installing {typeof(NavigationInstaller)}");
		Container.BindInstance(screensContainer);
		Container.BindInstance(screensRootRectTransform);
		
		Container.Bind<ScreenFactory>().AsCached();
		Container.BindFactory<Object, Screen, Screen.Factory>().FromFactory<ScreenFactory>();
		
		Container.Bind<Navigation>().AsSingle();
		BindPresenters();
	}

	private void BindPresenters()
	{
		if(screensContainer == null)
		{
			Debug.LogWarning($"Screens Container is not assigned in {this.name}");
			return;
		}

		var presenters = screensContainer.GetScreensPresenters();
		foreach (var presenterType in presenters)
		{
			if (presenterType == null)
			{
				continue;
			}
			Container.Bind(presenterType).AsSingle();
		}
	}
}