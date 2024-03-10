using System.Threading.Tasks;
using UnityEngine;

public static class Extensions
{
	public static async Task AwaitAsyncOperation(this AsyncOperation asyncOperation)
	{
		var taskCompletionSource = new TaskCompletionSource<object>();
		asyncOperation.completed += operation => taskCompletionSource.SetResult(null);
		await taskCompletionSource.Task;
	}

	public static void SetLayerRecursively(this Transform parent, int layer)
	{
		parent.gameObject.layer = layer;

		for (int i = 0, count = parent.childCount; i < count; i++)
		{
			parent.GetChild(i).SetLayerRecursively(layer);
		}
	}
}