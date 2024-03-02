using System.Collections.Generic;
using UnityEngine;

public class GameService
{
	private readonly OrdersService ordersService;

	public GameService(PlayerControlsService playerControlsService, OrdersService ordersService)
	{
		this.ordersService = ordersService;

		playerControlsService.OnIngredientGameControlClicked += OnIngredientControlClicked;
	}

	public void StartGame()
	{
		//ToDo: Initialize UI
		//Create Orders
		ordersService.CreateOrder(2);
	}

	private void OnIngredientControlClicked(IngredientGameControlEventData ingredientControlData)
	{
		Debug.Log($"Ingredient {ingredientControlData.IngredientData.Ingredient.Name}");
	}
}

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
		var orderView = ordersViewSpawner.CreateOrderView(order);
		ordersViews.Add(orderView);
	}
}
