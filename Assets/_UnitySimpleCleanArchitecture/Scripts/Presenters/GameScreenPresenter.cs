using Zenject;

public class GameScreenPresenter
{
	private GameScreen screen;
	private Navigation navigation;

	[Inject]
	public void Inject(Navigation navigation, SceneTransitioner sceneTransitioner, GameScreen screen)
	{
		this.navigation = navigation;
		this.screen = screen;
	}

	public void CreateScreen()
	{
		screen = navigation.Create<GameScreen>();
	}

	public void RemoveScreen()
	{
		navigation.Remove(screen);
	}
}