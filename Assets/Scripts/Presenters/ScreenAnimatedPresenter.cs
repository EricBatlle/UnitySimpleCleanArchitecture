using Zenject;

public class ScreenAnimatedPresenter
{
    private Navigation navigation;

    [Inject]
    public void Initialize(Navigation navigation)
    {
        this.navigation = navigation;
    }
    
    public void RemoveScreen(Screen screen)
    {
        navigation.Remove(screen);
    }
}
