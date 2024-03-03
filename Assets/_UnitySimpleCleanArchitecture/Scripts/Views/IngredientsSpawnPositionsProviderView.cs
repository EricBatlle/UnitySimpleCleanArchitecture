using System;
using System.Collections.Generic;
using UnityEngine;

// This acts as IngredientSpawnPositionProvider, but since it's a Monobehaviour, is called View
public class IngredientsSpawnPositionsProviderView : MonoBehaviour
{
	[Serializable]
	public class IngredientGameTouchControlSpawnPosition
	{
		public IngredientGameTouchControl touchControl;
		public RectTransform spawnPosition;
	}

	[SerializeField]
	private List<IngredientGameTouchControlSpawnPosition> ingredientGameTouchControlSpawnPositions;

	public Vector3 GetIngredientSpawnPosition(IngredientData ingredientData)
	{
		var spawnPosition = ingredientGameTouchControlSpawnPositions.Find(test => test.touchControl.IngredientId == ingredientData.IngredientId).spawnPosition;
		return spawnPosition.localPosition;
	}
}
