using UnityEngine.SceneManagement;
using Zenject;

public class MetaScreenPresenter
{
	private MetaScreen screen;
	private Navigation navigation;
	private SceneTransitioner sceneTransitioner;

	[Inject]
	public void Initialize(Navigation navigation, SceneTransitioner sceneTransitioner)
	{
		this.navigation = navigation;
		this.sceneTransitioner = sceneTransitioner;
	}

	public void CreateScreen()
	{
		screen = navigation.Create<MetaScreen>();
	}

	public void RemoveScreen()
	{
		navigation.Remove(screen);
	}

	public void OnPlayButtonClicked()
	{
		sceneTransitioner.TransitionFromTo(SceneManager.GetActiveScene().name, ScenesNames.GAME_SCENE_NAME);
	}
}
