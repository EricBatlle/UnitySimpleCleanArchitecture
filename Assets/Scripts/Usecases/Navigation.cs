using UnityEngine;
using Zenject;

public class Navigation
{
    private readonly ScreensContainer screensContainer;
    private readonly Screen.Factory screenFactory;
    private readonly RectTransform screensRectTransformRoot;

    [Inject]
    public Navigation(ScreensContainer screensContainer, Screen.Factory screenFactory, RectTransform screensRectTransformRoot)
    {
        this.screensContainer = screensContainer;
        this.screenFactory = screenFactory;
        this.screensRectTransformRoot = screensRectTransformRoot;
    }

    public void Create<TScreen>() where TScreen : Screen
    {
        var screenPrefab = screensContainer.GetScreenPrefab<TScreen>();
        if (screenPrefab == null) {
            Debug.LogError($"No Screen of type {typeof(TScreen)}");
            return;
        }
        var screen = screenFactory.Create(screenPrefab);
        screen.transform.SetParent(screensRectTransformRoot, false);
    }
    
    public void Create<TScreen, TScreenIntent>(TScreenIntent screenIntent) where TScreen : ScreenWithIntent<TScreenIntent> where TScreenIntent : ScreenIntent
    {
        var screenPrefab = screensContainer.GetScreenPrefab<TScreen>();
        if (screenPrefab == null) {
            Debug.LogError($"No Screen of type {typeof(TScreen)}");
            return;
        }
        var screen = screenFactory.Create(screenPrefab) as ScreenWithIntent<TScreenIntent>;
        if (screen == null) {
            Debug.LogError($"Trying to create screen of type {typeof(TScreen)} with Intent of type {typeof(TScreenIntent)}. Probably Screen is not marked as ScreenWithIntent.");
            return;
        }
        
        screen.SetIntent(screenIntent);
        screen.transform.SetParent(screensRectTransformRoot, false);
    }

    public void Remove(Screen screen)
    {
        UnityEngine.Object.Destroy(screen.gameObject);
    }
}