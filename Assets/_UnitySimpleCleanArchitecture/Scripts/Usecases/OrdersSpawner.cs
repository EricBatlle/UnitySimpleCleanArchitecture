using UnityEngine;

public class OrdersSpawner
{
	private readonly OrderView.Factory ordersViewFactory;
	private readonly OrderView orderViewPrefab;
	private readonly Transform parent;

	public OrdersSpawner(OrderView.Factory ordersViewFactory, OrderView orderViewPrefab, Transform parent)
	{
		this.ordersViewFactory = ordersViewFactory;
		this.orderViewPrefab = orderViewPrefab;
		this.parent = parent;
	}

	public void CreateOrder(Order order)
	{
		var orderView = ordersViewFactory.Create(orderViewPrefab, order);
		orderView.transform.SetParent(parent, false);
	}
}