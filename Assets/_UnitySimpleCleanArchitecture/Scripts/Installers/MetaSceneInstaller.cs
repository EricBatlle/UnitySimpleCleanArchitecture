using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MetaSceneInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<SceneTransitioner>().AsSingle().NonLazy();
	}
}
