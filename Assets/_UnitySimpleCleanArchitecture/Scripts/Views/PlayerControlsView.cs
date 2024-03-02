using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerControlsView : MonoBehaviour
{
	[SerializeField]
	private IngredientGameTouchControl rightGameTouchControlButton;
	[SerializeField]
	private IngredientGameTouchControl leftGameTouchControlButton;

	private PlayerControlsPresenter presenter;

	[Inject]
	public void Inject(PlayerControlsPresenter presenter)
	{
		this.presenter = presenter;
	}

	private void Awake()
	{
		rightGameTouchControlButton.OnClick += OnGameTouchControlClicked;
		leftGameTouchControlButton.OnClick += OnGameTouchControlClicked;
	}

	private void OnGameTouchControlClicked(IngredientData ingredientData)
	{
		presenter.GameTouchControlClicked(ingredientData);
	}
}
