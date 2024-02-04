using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ScreenWithIntentView : ScreenWithIntent<ScreenIntentTest>
{
    [SerializeField]
    private Text text;
    [SerializeField]
    private Button button;

    private ScreenWithIntentPresenter presenter;
    public override Type GetPresenterType() => typeof(ScreenWithIntentPresenter);

    [Inject]
    public void Initialize(ScreenWithIntentPresenter presenter)
    {
        Debug.Log($"Injected in {this.name}");
        this.presenter = presenter;
        //button.onClick.AddListener(() => presenter.CloseScreen(this));
    }

    protected override void OnIntentSetCompleted()
    {
        text.text = Intent.Text;
    }
}
