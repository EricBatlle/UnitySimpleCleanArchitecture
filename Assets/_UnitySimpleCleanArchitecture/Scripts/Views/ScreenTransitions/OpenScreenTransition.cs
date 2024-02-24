using DG.Tweening;
using System;
using UnityEngine;

public class OpenScreenTransition : ScreenTransition
{
	[SerializeField]
	protected float duration = 0.35f;
	[SerializeField]
	protected Ease easeIn = Ease.OutBack;

	private Tween openCloseTween;

	public override void Animate(Transform target, Action onComplete = null)
	{
		target.localScale = Vector3.zero;
		openCloseTween?.Kill();
		openCloseTween = target.DOScale(Vector3.one, duration)
			.SetEase(easeIn)
			.OnComplete(() => onComplete?.Invoke());
	}
}