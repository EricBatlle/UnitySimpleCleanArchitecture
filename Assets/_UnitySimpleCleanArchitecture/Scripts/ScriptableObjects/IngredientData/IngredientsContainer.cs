using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IngredientsContainer", menuName = "ScriptableObjects/IngredientsContainer")]
public class IngredientsContainer : ScriptableObject
{
	[SerializeField]
	private List<IngredientData> allIngredients;

	public List<IngredientData> AllIngredients => allIngredients;
}