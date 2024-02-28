using System.Threading.Tasks;
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
		screen.transform.SetParent(screensRectTransformRoot, false);
		screen.StretchCompletly();

#pragma warning disable CS4014 // Dado que no se esperaba esta llamada, la ejecución del método actual continuará antes de que se complete la llamada
		screen.Show();
#pragma warning restore CS4014 // Dado que no se esperaba esta llamada, la ejecución del método actual continuará antes de que se complete la llamada
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
#pragma warning disable CS4014 // Dado que no se esperaba esta llamada, la ejecución del método actual continuará antes de que se complete la llamada
		screen.SetIntentAndShow(screenIntent);
#pragma warning restore CS4014 // Dado que no se esperaba esta llamada, la ejecución del método actual continuará antes de que se complete la llamada
		return (TScreen)screen;
	}

	public async void Remove(Screen screen)
	{
		await screen.Hide();
		Object.Destroy(screen.gameObject);
	}
}