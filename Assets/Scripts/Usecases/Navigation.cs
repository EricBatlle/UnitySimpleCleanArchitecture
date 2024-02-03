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

    public void Create<T>() where T : Screen
    {
        var screenPrefab = screensContainer.GetScreenPrefab<T>();
        if (screenPrefab == null) {
            Debug.LogError($"No Screen of type {typeof(T)}");
            return;
        }
        var screen = screenFactory.Create(screenPrefab);
        screen.transform.SetParent(screensRectTransformRoot, false);
    }

    public void Remove(Screen screen)
    {
        UnityEngine.Object.Destroy(screen.gameObject);
    }
}