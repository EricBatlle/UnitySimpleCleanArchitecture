using Zenject;

public class MetaScreenPresenter
{
	private Navigation navigation;
	private MetaScreen screen;

	[Inject]
	public void Initialize(Navigation navigation)
	{
		this.navigation = navigation;
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

	}
}
