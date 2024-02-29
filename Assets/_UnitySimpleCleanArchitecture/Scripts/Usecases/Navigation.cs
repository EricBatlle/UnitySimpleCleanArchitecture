using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class ProjectNavigation : Navigation 
{
	[Inject]
	public ProjectNavigation(ScreensContainer screensContainer, ScreenFactory screenFactory, RectTransform screensRectTransformRoot) : base(screensContainer, screenFactory, screensRectTransformRoot)
	{
	}
}

public class Navigation
{
	protected readonly ScreensContainer screensContainer;
	protected readonly ScreenFactory screenFactory;
	protected readonly RectTransform screensRectTransformRoot;

	[Inject]
	public Navigation(ScreensContainer screensContainer, ScreenFactory screenFactory, RectTransform screensRectTransformRoot)
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
		var screen = screenFactory.Create(screenPrefab, screensRectTransformRoot);

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
		Object.Destroy(screen.gameObject);
	}
	
	public async Task HideAndRemove(Screen screen)
	{
		await screen.Hide();
		Object.Destroy(screen.gameObject);
	}
}