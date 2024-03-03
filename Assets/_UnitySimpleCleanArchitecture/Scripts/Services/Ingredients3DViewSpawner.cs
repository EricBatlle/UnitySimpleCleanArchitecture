using UnityEngine;

public class Ingredients3DViewSpawner
{
	private readonly Ingredient3DView.Factory ingredients3DViewFactory;
	private readonly Transform parent;
	private readonly IngredientsSpawnPositionsProviderView ingredientsSpawnerView;

	public Ingredients3DViewSpawner(Ingredient3DView.Factory ingredients3DViewFactory, Transform parent, IngredientsSpawnPositionsProviderView ingredientsSpawnerView)
	{
		this.ingredients3DViewFactory = ingredients3DViewFactory;
		this.parent = parent;
		this.ingredientsSpawnerView = ingredientsSpawnerView;
	}

	public Ingredient3DView Spawn(IngredientData ingredientData)
	{
		var spawnPosition = ingredientsSpawnerView.GetIngredientSpawnPosition(ingredientData);
		var ingredient3DView = ingredients3DViewFactory.Create(ingredientData.Model3D);
		ingredient3DView.transform.SetParent(parent, false);
		ingredient3DView.SetInitialPositionAndShootUp(spawnPosition);
		return ingredient3DView;
	}
}