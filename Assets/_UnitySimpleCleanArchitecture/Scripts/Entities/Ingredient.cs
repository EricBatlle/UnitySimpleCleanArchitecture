using System;
using UnityEngine;

[Serializable]
public class Ingredient
{
	[SerializeField]
	private int id;
	[SerializeField]
	private string name;
	[SerializeField]
	private int value;

	public int Id => id;
	public string Name => name;
	public int Value => value;
}
