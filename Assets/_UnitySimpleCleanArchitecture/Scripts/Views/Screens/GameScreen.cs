using System;
using UnityEngine;
using Zenject;

public class GameScreen : Screen
{
	public override Type GetPresenterType() => typeof(GameScreenPresenter);
	
	private GameScreenPresenter presenter;

	[Inject]
	public void Inject(GameScreenPresenter presenter)
	{
		this.presenter = presenter;
	}
}