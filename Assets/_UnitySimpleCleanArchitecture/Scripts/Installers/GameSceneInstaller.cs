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
	[Space()]
	[SerializeField]
	private Transform ingredients3DViewParent;
	[SerializeField]
	private IngredientsSpawnPositionsProviderView ingredientsSpawnerView;
	[Header("ScriptableObjects")]
	[SerializeField]
	private IngredientsContainer ingredientsContainer;

	public override void InstallBindings()
	{
		Debug.Log($"Installing {typeof(GameSceneInstaller)}");

		Container.Bind<GameService>().AsSingle();
		Container.Bind<PlayerControlsService>().AsSingle();
		Container.Bind<PlayerControlsPresenter>().AsSingle();

		Container.Bind<OrdersService>().AsSingle();
		Container.Bind<OrderRandomGenerator>().AsSingle();

		Container.Bind<IngredientsProvider>().AsSingle();
		Container.Bind<IngredientsContainer>().FromScriptableObject(ingredientsContainer).AsSingle();
		
		Container.Bind<GameScreen>().FromInstance(gameScreen).AsSingle();
		Container.Bind<StartGameOverlayScreen>().FromInstance(startGameOverlay).AsSingle();

		InstallOrdersViewSpawner();
		InstallIngredients3DViewSpawner();
	}

	private void InstallIngredients3DViewSpawner()
	{
		Container.Bind<Ingredients3DViewSpawner>().AsSingle();
		Container.Bind<Transform>().FromInstance(ingredients3DViewParent).AsCached().WhenInjectedInto<Ingredients3DViewSpawner>();
		Container.BindFactory<Object, Ingredient3DView, Ingredient3DView.Factory>().FromFactory<PrefabFactory<Ingredient3DView>>();
		Container.Bind<IngredientsSpawnPositionsProviderView>().FromInstance(ingredientsSpawnerView).AsSingle();
	}

	private void InstallOrdersViewSpawner()
	{
		Container.Bind<OrdersViewSpawner>().AsSingle();
		Container.Bind<OrderView>().FromInstance(orderViewPrefab).AsSingle();
		Container.Bind<Transform>().FromInstance(ordersViewParent).AsCached().WhenInjectedInto<OrdersViewSpawner>();
		Container.BindFactory<Object, Order, OrderView, OrderView.Factory>().FromFactory<PrefabFactory<Order, OrderView>>();
	}
}