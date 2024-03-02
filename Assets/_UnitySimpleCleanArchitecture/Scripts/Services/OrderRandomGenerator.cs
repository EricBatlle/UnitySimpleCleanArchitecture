using System.Collections.Generic;
using UnityEngine;

public class OrderRandomGenerator
{
	private readonly IngredientsProvider ingredientsProvider;

	public OrderRandomGenerator(IngredientsProvider ingredientsProvider)
	{
		this.ingredientsProvider = ingredientsProvider;
	}

	public Order Generate(int maxIngredientsCounts)
	{
		var orderIngredients = new List<Ingredient>();
		int ingredientsCount = Random.Range(1, maxIngredientsCounts + 1);
		for (int i = 0; i < ingredientsCount; i++)
		{
			orderIngredients.Add(ingredientsProvider.GetRandomIngredient());
		}
		var order = new Order(orderIngredients);
		return order;
	}
}