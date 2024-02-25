using UnityEngine;
using Zenject;

public class ProjectContextInstaller : MonoInstaller
{
	[SerializeField]
	private ScreensContainer screensContainer;

	[SerializeField]
	private RectTransform screensRootRectTransform;

	public override void InstallBindings()
	{
		Debug.Log($"Installing {this.name}");
		SignalBusInstaller.Install(Container);


		Container.BindInstance(screensContainer);
		Container.BindInstance(screensRootRectTransform);
		Container.BindFactory<UnityEngine.Object, Screen, Screen.Factory>().FromFactory<PrefabFactory<Screen>>();

		Container.Bind<ProjectNavigation>().AsSingle();
		Container.Bind<TransitionScreenPresenter>().AsSingle().NonLazy();
		Container.Bind<SceneTransitioner>().AsSingle().NonLazy();
	}
}
