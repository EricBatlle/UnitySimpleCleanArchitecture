using System;
using UnityEngine;
using Zenject;

public class TransitionScreen : Screen
{
	public override Type GetPresenterType() => typeof(TransitionScreenPresenter);
	
	private TransitionScreenPresenter presenter;

	[Inject]
	public void Inject(TransitionScreenPresenter presenter)
	{
		this.presenter = presenter;
	}
}