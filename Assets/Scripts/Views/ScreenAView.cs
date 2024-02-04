using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ScreenAView : Screen
{
    [SerializeField]
    private Text text;
    [SerializeField]
    private Button button;

    private ScreenAPresenter presenter;
    public override Type GetPresenterType() => typeof(ScreenAPresenter);

    [Inject]
    public void Initialize(ScreenAPresenter presenter)
    {
        Debug.Log("Initialize ScreenAViewInjection");
        this.presenter = presenter;
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        presenter.OnButtonClicked(this);
    }
}
