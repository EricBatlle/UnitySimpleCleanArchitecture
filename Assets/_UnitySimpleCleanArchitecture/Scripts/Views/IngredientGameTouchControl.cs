using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class IngredientGameTouchControl : MonoBehaviour
{
	[SerializeField]
	private RectTransform rectTransform;
	[SerializeField]
	private Button button;
	[SerializeField]
	private IngredientData ingredient;

	public int IngredientId => ingredient.IngredientId;
	public RectTransform RectTransform => rectTransform;

	public event Action<IngredientData> OnClick;

	private void Awake()
	{
		button.onClick.AddListener(()=>OnClick(ingredient));
	}
}
