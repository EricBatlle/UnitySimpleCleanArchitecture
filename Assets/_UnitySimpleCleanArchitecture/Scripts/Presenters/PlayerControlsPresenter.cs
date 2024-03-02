public class PlayerControlsPresenter
{
	private readonly PlayerControlsService playerControlsService;

	public PlayerControlsPresenter(PlayerControlsService playerControlsService)
	{
		this.playerControlsService = playerControlsService;
	}

	public void GameTouchControlClicked(IngredientData ingredientData)
	{
		playerControlsService.SendIngredientControlClicked(new IngredientGameControlEventData(ingredientData));
	}
}