using UnityEngine;

public class OrdersViewSpawner
{
	private readonly OrderView.Factory ordersViewFactory;
	private readonly OrderView orderViewPrefab;
	private readonly Transform parent;

	public OrdersViewSpawner(OrderView.Factory ordersViewFactory, OrderView orderViewPrefab, Transform parent)
	{
		this.ordersViewFactory = ordersViewFactory;
		this.orderViewPrefab = orderViewPrefab;
		this.parent = parent;
	}

	public OrderView CreateOrderView(Order order)
	{
		var orderView = ordersViewFactory.Create(orderViewPrefab, order);
		orderView.transform.SetParent(parent, false);
		return orderView;
	}
}