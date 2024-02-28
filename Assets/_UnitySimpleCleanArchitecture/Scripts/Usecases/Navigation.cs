using UnityEngine;
using Zenject;

public class ProjectNavigation : Navigation 
{
	[Inject]
	public ProjectNavigation(ScreensContainer screensContainer, Screen.Factory screenFactory, RectTransform screensRectTransformRoot) : base(screensContainer, screenFactory, screensRectTransformRoot)
	{
	}
}

public class Navigation
{
	protected readonly ScreensContainer screensContainer;
	protected readonly Screen.Factory screenFactory;
	protected readonly RectTransform screensRectTransformRoot;

	[Inject]
	public Navigation(ScreensContainer screensContainer, Screen.Factory screenFactory, RectTransform screensRectTransformRoot)
	{
		this.screensContainer = screensContainer;
		this.screenFactory = screenFactory;
		this.screensRectTransformRoot = screensRectTransformRoot;
	}

	public TScreen Create<TScreen>() where TScreen : Screen
	{
		var screenPrefab = screensContainer.GetScreenPrefab<TScreen>();
		if (screenPrefab == null)
		{
			Debug.LogError($"No Screen of type {typeof(TScreen)} in {typeof(ScreensContainer)}");
			return null;
		}
		var screen = screenFactory.Create(screenPrefab);
		screen.GetComponent<RectTransform>().SetParent(screensRectTransformRoot, false);
		var rectTransform = screen.GetComponent<RectTransform>();
		rectTransform.anchorMin = Vector2.zero;
		rectTransform.anchorMax = new Vector2(1, 1);
		rectTransform.anchoredPosition = Vector2.zero;
		rectTransform.sizeDelta = Vector2.zero;
		rectTransform.pivot = new Vector2(0.5f, 0.5f);

		screen.Show();
		return (TScreen)screen;
	}

	public TScreen Create<TScreen, TScreenIntent>(TScreenIntent screenIntent) where TScreen : ScreenWithIntent<TScreenIntent> where TScreenIntent : ScreenIntent
	{
		var screenPrefab = screensContainer.GetScreenPrefab<TScreen>();
		if (screenPrefab == null)
		{
			Debug.LogError($"No Screen of type {typeof(TScreen)}");
			return null;
		}
		var screen = screenFactory.Create(screenPrefab) as ScreenWithIntent<TScreenIntent>;
		if (screen == null)
		{
			Debug.LogError($"Trying to create screen of type {typeof(TScreen)} with Intent of type {typeof(TScreenIntent)}. Probably Screen is not marked as ScreenWithIntent.");
			return null;
		}

		screen.transform.SetParent(screensRectTransformRoot, false);
		screen.SetIntentAndShow(screenIntent);
		return (TScreen)screen;
	}

	public void Remove(Screen screen)
	{
		UnityEngine.Object.Destroy(screen.gameObject);
	}
}