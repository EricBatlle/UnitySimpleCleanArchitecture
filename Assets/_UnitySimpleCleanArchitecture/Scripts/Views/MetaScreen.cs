using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MetaScreen : Screen
{
	[SerializeField]
	private RectTransform parent;
	[SerializeField]
	private GameObject A;
	[SerializeField]
	private Button playButton;

	public override Type GetPresenterType() => typeof(MetaScreenPresenter);

	private MetaScreenPresenter presenter;

	[Inject]
	public void Inject(MetaScreenPresenter presenter)
	{
		this.presenter = presenter;
	}

	private void Awake()
	{
		playButton.onClick.AddListener(OnPlayButton);
	}

	[ContextMenu("Play")]
	private void OnPlayButton()
	{
		presenter.OnPlayButtonClickedAsync();
	}
}
