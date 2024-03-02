using UnityEngine;

public class GameService
{
	private OrdersSpawner ordersSpawner;

	public GameService(PlayerControlsService playerControlsService, OrdersSpawner ordersSpawner)
	{
		this.ordersSpawner = ordersSpawner;

		playerControlsService.OnIngredientGameControlClicked += OnIngredientControlClicked;
	}

	public void StartGame()
	{
		//ToDo: Initialize UI
		//Create Orders
		ordersSpawner.CreateOrder(new Order());
	}

	private void OnIngredientControlClicked(IngredientGameControlEventData ingredientControlData)
	{
		Debug.Log($"Ingredient {ingredientControlData.IngredientData.Ingredient.Name}");
	}
}

//ToDo: I'm working on this!
public class OrdersService
{
	private OrdersSpawner ordersSpawner;

	public OrdersService(OrdersSpawner ordersSpawner)
	{
		this.ordersSpawner = ordersSpawner;
	}
}
