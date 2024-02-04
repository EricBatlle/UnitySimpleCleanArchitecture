using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ScreenAnimatedView : ScreenWithIntent<ScreenIntentTest>
{
    [SerializeField]
    private Button hideButton;
    
    public override Type GetPresenterType() => typeof(ScreenAnimatedPresenter);
    private ScreenAnimatedPresenter presenter;
    
    [Inject]
    public void Initialize(ScreenAnimatedPresenter presenter)
    {
        this.presenter = presenter;
        hideButton.onClick.AddListener(Hide);
    }
    
    protected override void OnIntentSetCompleted()
    {
        hideButton.GetComponentInChildren<Text>().text = Intent.Text;
    }

    protected override void OnHideAnimationComplete()
    {
        base.OnHideAnimationComplete();
        presenter.RemoveScreen(this);
    }
}