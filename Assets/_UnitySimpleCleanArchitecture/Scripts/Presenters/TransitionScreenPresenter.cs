using System.Threading.Tasks;
using Zenject;

public class TransitionScreenPresenter
{
	private TransitionScreen screen;
	private ProjectNavigation navigation;

	private TaskCompletionSource<bool> openAnimationTaskCompletionSource;
	private TaskCompletionSource<bool> hideAnimationTaskCompletionSource;


	[Inject]
	public void Initialize(ProjectNavigation navigation)
	{
		this.navigation = navigation;
	}

	public void CreateScreen()
	{
		screen = navigation.Create<TransitionScreen>();
		screen.OpenAnimationComplete += OnOpenAnimationComplete;
		screen.HideAnimationComplete += OnHideAnimationComplete;
	}

	public async Task HideScreen()
	{
		await screen.Hide();
	}

	public Task OpenAnimationComplete()
	{
		openAnimationTaskCompletionSource = new TaskCompletionSource<bool>();
		return openAnimationTaskCompletionSource.Task;
	}

	public Task HideAnimationComplete()
	{
		hideAnimationTaskCompletionSource = new TaskCompletionSource<bool>();
		return hideAnimationTaskCompletionSource.Task;
	}

	private void OnOpenAnimationComplete()
	{
		openAnimationTaskCompletionSource.SetResult(true);
	}
	
	private void OnHideAnimationComplete()
	{
		hideAnimationTaskCompletionSource.SetResult(true);
		navigation.Remove(screen);
	}
}