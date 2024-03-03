using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "ScriptableObjects/Ingredient")]
public class IngredientData : ScriptableObject
{
	[SerializeField]
	private Ingredient ingredient;
	[SerializeField]
	private GameObject model3D;

	public Ingredient Ingredient => ingredient;
	public GameObject Model3D => model3D;
	public int IngredientId => ingredient.Id;
}