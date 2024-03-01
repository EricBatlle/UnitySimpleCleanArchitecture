using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StartGameOverlayScreen : Screen
{
	[SerializeField]
	private Button tapToPlayButton;

	public override Type GetPresenterType() => typeof(StartGameOverlayScreenPresenter);
	
	private StartGameOverlayScreenPresenter presenter;

	[Inject]
	public void Inject(StartGameOverlayScreenPresenter presenter)
	{
		this.presenter = presenter;
	}

	private void Awake()
	{
		tapToPlayButton.onClick.AddListener(OnTapToPlayButton);
	}

	private void OnTapToPlayButton()
	{
		presenter.OnTapToPlayButtonClicked();
	}
}