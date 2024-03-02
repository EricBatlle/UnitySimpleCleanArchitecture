using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Order
{
	[SerializeField]
	private List<Ingredient> requiredIngredients;

	public List<Ingredient> RequiredIngredients { get => requiredIngredients; }
}