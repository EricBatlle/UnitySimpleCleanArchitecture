using System.Collections.Generic;

public class OrdersService
{
	private readonly OrdersViewSpawner ordersViewSpawner;
	private readonly OrderRandomGenerator orderRandomGenerator;

	private readonly List<OrderView> ordersViews = new List<OrderView>();

	public OrdersService(OrdersViewSpawner ordersViewSpawner, OrderRandomGenerator orderRandomGenerator)
	{
		this.ordersViewSpawner = ordersViewSpawner;
		this.orderRandomGenerator = orderRandomGenerator;
	}

	public void CreateOrder(int maxIngredientsPerOrder)
	{
		var order = orderRandomGenerator.Generate(maxIngredientsPerOrder);
		var orderView = ordersViewSpawner.Spawn(order);
		ordersViews.Add(orderView);
	}
}
