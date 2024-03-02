using UnityEngine;
using Zenject;

public class OrderView : MonoBehaviour
{
	[SerializeField]
	private Order order;

	[Inject]
	public void Inject(Order order)
	{
		this.order = order;
	}

	public class Factory : PlaceholderFactory<Object, Order, OrderView>
	{
	}
}