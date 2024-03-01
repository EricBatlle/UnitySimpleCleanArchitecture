using System.Threading.Tasks;
using Zenject;

public class TransitionScreenPresenter
{
	private TransitionScreen screen;
	private ProjectNavigation navigation;

	private TaskCompletionSource<bool> openAnimationTaskCompletionSource;


	[Inject]
	public void Inject(ProjectNavigation navigation)
	{
		this.navigation = navigation;
	}

	public void CreateScreen()
	{
		screen = navigation.Create<TransitionScreen>();
		screen.OpenAnimationComplete += OnOpenAnimationComplete;
	}

	public async Task HideAndRemoveScreen()
	{
		await navigation.HideAndRemove(screen);
	}

	public Task OpenAnimationComplete()
	{
		openAnimationTaskCompletionSource = new TaskCompletionSource<bool>();
		return openAnimationTaskCompletionSource.Task;
	}


	private void OnOpenAnimationComplete()
	{
		openAnimationTaskCompletionSource.SetResult(true);
	}
}