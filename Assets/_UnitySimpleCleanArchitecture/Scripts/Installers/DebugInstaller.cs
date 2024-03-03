using UnityEngine;
using Zenject;

public class DebugInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
#if UNITY_EDITOR
		Debug.Log("GameStart Installer");
		Container.Resolve<StartGameOverlayScreenPresenter>().OnTapToPlayButtonClicked();
#endif
	}
}