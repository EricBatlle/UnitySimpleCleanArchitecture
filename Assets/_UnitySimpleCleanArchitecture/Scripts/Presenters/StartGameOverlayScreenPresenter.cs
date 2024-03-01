using Zenject;

public class StartGameOverlayScreenPresenter
{
	private StartGameOverlayScreen screen;
	private Navigation navigation;
	private GameService gameService;

	[Inject]
	public void Inject(Navigation navigation, GameService gameService, StartGameOverlayScreen screen)
	{
		this.navigation = navigation;
		this.gameService = gameService;
		this.screen = screen;
	}

	public void CreateScreen()
	{
		screen = navigation.Create<StartGameOverlayScreen>();
	}

	public void RemoveScreen()
	{
		navigation.Remove(screen);
	}

	public void OnTapToPlayButtonClicked()
	{
		RemoveScreen();
		gameService.StartGame();
	}
}