using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "ScriptableObjects/Ingredient")]
public class IngredientData : ScriptableObject
{
	[SerializeField]
	private Ingredient ingredient;
}