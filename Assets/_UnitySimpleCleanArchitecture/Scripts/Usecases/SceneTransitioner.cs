using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner
{
	private TransitionScreenPresenter transitionPresenter;

	public SceneTransitioner(TransitionScreenPresenter transitionPresenter)
	{
		this.transitionPresenter = transitionPresenter;
	}

	public async void TransitionFromTo(string originSceneName, string destinationSceneName, Action OnTransitionEnd = null)
	{
		await LoadScene(ScenesNames.TRANSITION_SCENE_NAME, LoadSceneMode.Additive);
		transitionPresenter.CreateScreen();
		
		await transitionPresenter.OpenAnimationComplete();
		await UnloadScene(originSceneName);
		await LoadScene(destinationSceneName, LoadSceneMode.Additive);
		transitionPresenter.RemoveScreen();
		await transitionPresenter.HideAnimationComplete();
		await UnloadScene(ScenesNames.TRANSITION_SCENE_NAME);
	}

	private async Task UnloadScene(string sceneName)
	{
		var asyncOperation = SceneManager.UnloadSceneAsync(sceneName);
		await asyncOperation.AwaitAsyncOperation();
		Debug.Log($"Unload Scene {sceneName}");
	}

	private async Task LoadScene(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
	{
		var asyncOperation = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
		await asyncOperation.AwaitAsyncOperation();
	}
}
