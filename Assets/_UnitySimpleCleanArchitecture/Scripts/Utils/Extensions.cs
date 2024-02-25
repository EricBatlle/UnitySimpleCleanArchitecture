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
}