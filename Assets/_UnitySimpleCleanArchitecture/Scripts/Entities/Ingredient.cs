using System;
using UnityEngine;

[Serializable]
public class Ingredient
{
	[SerializeField]
	private string name;
	[SerializeField]
	private int value;

	public string Name => name;
	public int Value => value;
}
