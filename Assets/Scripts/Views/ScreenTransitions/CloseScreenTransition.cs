using System;
using DG.Tweening;
using UnityEngine;

public class CloseScreenTransition : ScreenTransition
{
    [SerializeField] 
    protected float duration = 0.35f;
    [SerializeField] 
    protected Ease easeOut = Ease.InBack;

    private Tween openCloseTween;

    public override void Animate(Transform target, Action onComplete = null)
    {
        openCloseTween?.Kill();
        openCloseTween = transform.DOScale(Vector3.zero, duration)
            .SetEase(easeOut)
            .OnComplete(() => onComplete?.Invoke());
    }
}