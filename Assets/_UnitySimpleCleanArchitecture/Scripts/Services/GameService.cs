using UnityEngine;

public class GameService
{
	private readonly OrdersService ordersService;
	private readonly Ingredients3DViewSpawner ingredients3DViewSpawner;

	public GameService(PlayerControlsService playerControlsService, OrdersService ordersService, Ingredients3DViewSpawner ingredients3DViewSpawner)
	{
		this.ordersService = ordersService;
		this.ingredients3DViewSpawner = ingredients3DViewSpawner;

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
		ingredients3DViewSpawner.Spawn(ingredientControlData.IngredientData);
	}
}
