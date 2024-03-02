using UnityEngine;

public class IngredientsProvider
{
	private IngredientsContainer ingredientsContainer;

	public IngredientsProvider(IngredientsContainer ingredientsContainer)
	{
		this.ingredientsContainer = ingredientsContainer;
	}

	public Ingredient GetRandomIngredient()
	{
		var allIngredients = ingredientsContainer.AllIngredients;
		var randomIngredientIndex = Random.Range(0, allIngredients.Count);
		return allIngredients[randomIngredientIndex].Ingredient;
	}
}
