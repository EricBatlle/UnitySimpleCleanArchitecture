using Zenject;

public class ScreenFactory : PrefabFactory<Screen>
{
	public ScreenFactory(DiContainer container) : base(container)
	{
	}
}
