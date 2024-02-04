using System;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

public abstract class Screen : MonoBehaviour
{
    [SerializeField]
    protected bool isHided;
    [SerializeField]
    protected ScreenTransition openScreenTransition;
    [SerializeField]
    protected ScreenTransition closeScreenTransition;
    
    public abstract Type GetPresenterType();

    protected virtual void OnOpenAnimationComplete()
    {
        isHided = false;
    }

    protected virtual void OnHideAnimationComplete()
    {
        isHided = true;
    }

    public virtual void Show()
    {
        if (openScreenTransition == null) {
            OnOpenAnimationComplete();
            return;
        }
        openScreenTransition.Animate(transform, OnOpenAnimationComplete);
    }

    protected virtual void Hide()
    {
        if (isHided || closeScreenTransition == null) {
            OnHideAnimationComplete();
            return;
        }
        closeScreenTransition.Animate(transform, OnHideAnimationComplete);
    }

    public class Factory : PlaceholderFactory<Object, Screen>
    {
    }
}