using System;

public class PlayerControlsService
{
	public event Action<IngredientGameControlEventData> OnIngredientGameControlClicked;

	public void SendIngredientControlClicked(IngredientGameControlEventData eventData)
	{
		OnIngredientGameControlClicked?.Invoke(eventData);
	}
}
