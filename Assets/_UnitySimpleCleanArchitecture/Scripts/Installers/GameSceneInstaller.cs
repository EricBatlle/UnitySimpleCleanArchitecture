using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
	[Header("Screens")]
	[SerializeField]
	private GameScreen gameScreen;
	[SerializeField]
	private StartGameOverlayScreen startGameOverlay;
	[Header("Factories prefabs")]
	[SerializeField]
	private OrderView orderViewPrefab;
	[SerializeField]
	private Transform ordersViewParent;
	
	public override void InstallBindings()
	{
		Container.Bind<GameService>().AsSingle();
		Container.Bind<PlayerControlsService>().AsSingle();
		Container.Bind<OrdersSpawner>().AsSingle();
		Container.Bind<PlayerControlsPresenter>().AsSingle();
		
		Container.Bind<GameScreen>().FromInstance(gameScreen).AsSingle();
		Container.Bind<StartGameOverlayScreen>().FromInstance(startGameOverlay).AsSingle();

		Container.Bind<OrderView>().FromInstance(orderViewPrefab).AsSingle();
		Container.Bind<Transform>().FromInstance(ordersViewParent).AsCached().WhenInjectedInto<OrdersSpawner>();
		Container.BindFactory<Object, Order, OrderView, OrderView.Factory>().FromFactory<PrefabFactory<Order, OrderView>>();
	}
}