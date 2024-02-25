using System;
using UnityEngine.SceneManagement;

public class SceneTransitioner
{
	public void TransitionFromTo(string originSceneName, string destinationSceneName, Action OnTransitionEnd = null)
	{
		LoadScene(ScenesNames.TRANSITION_SCENE_NAME, LoadSceneMode.Additive, () =>
		{
			UnloadScene(originSceneName, () =>
			{
				LoadScene(destinationSceneName, LoadSceneMode.Additive, () =>
				{
					UnloadScene(ScenesNames.TRANSITION_SCENE_NAME, OnTransitionEnd);
				});
			});
		});
	}

	private void UnloadScene(string sceneName, Action OnSceneUnloaded = null)
	{
		var asyncOperation = SceneManager.UnloadSceneAsync(sceneName);
		asyncOperation.completed += (operation) => OnSceneUnloaded?.Invoke();
	}

	private void LoadScene(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single, Action OnSceneLoaded = null)
	{
		var asyncOperation = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
		asyncOperation.completed += (operation) => OnSceneLoaded?.Invoke();
	}
}
