using System;
using System.Threading.Tasks;
using UnityEngine;

public class ScreenAnimatedView : ScreenWithIntent<ScreenIntentTest>
{
    [SerializeField]
    private ScreenTransition openScreenTransition;
    [SerializeField]
    private ScreenTransition closeScreenTransition;
    
    // ToDo: Test what happens with null presenter type
    public override Type GetPresenterType() => null;

    private async void OnOpenAnimationComplete()
    {
        await Task.Delay(1000);
        closeScreenTransition.Animate(transform, OnCloseAnimationComplete);
    }

    private void OnCloseAnimationComplete()
    {
        Debug.Log("Closed Screen");
    }

    protected override void OnIntentSetCompleted()
    {
        openScreenTransition.Animate(transform, OnOpenAnimationComplete);
    }
}