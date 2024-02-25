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
		Debug.Log($"Installing {this.name}");
		Container.BindInstance(screensContainer);
		Container.BindInstance(screensRootRectTransform);
		Container.BindFactory<UnityEngine.Object, Screen, Screen.Factory>().FromFactory<PrefabFactory<Screen>>();
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