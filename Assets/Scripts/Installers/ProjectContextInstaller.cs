using UnityEngine;
using Zenject;

public class ProjectContextInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Debug.Log($"Installing {this.name}");
		SignalBusInstaller.Install(Container);
	}
}
