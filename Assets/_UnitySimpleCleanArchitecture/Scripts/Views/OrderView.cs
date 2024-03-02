using System.Linq;
using TMPro;
using UnityEngine;
using Zenject;

public class OrderView : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI orderText;
	[SerializeField]
	private Order order;

	[Inject]
	public void Inject(Order order)
	{
		this.order = order;
	}

	private void Awake()
	{
		var orderIngredients = order.RequiredIngredients.Select(ingredient => ingredient.Name);
		var orderString = string.Join("", orderIngredients);
		orderText.text = orderString;
	}

	public class Factory : PlaceholderFactory<Object, Order, OrderView>
	{
	}
}