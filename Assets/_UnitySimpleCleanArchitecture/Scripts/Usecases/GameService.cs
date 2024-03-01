public class GameService
{
	private OrdersSpawner ordersSpawner;
	public GameService(OrdersSpawner ordersSpawner)
	{
		this.ordersSpawner = ordersSpawner;
	}

	public void StartGame()
	{
		//ToDo: Initialize UI
		//Create Orders
		ordersSpawner.CreateOrders();
	}
}