using DG.Tweening;
using System;
using System.Threading.Tasks;
using UnityEngine;

public class OpenScreenTransition : ScreenTransition
{
	[SerializeField]
	protected float duration = 0.35f;
	[SerializeField]
	protected Ease easeIn = Ease.OutBack;

	private Tween openCloseTween;

	public override async Task Animate(Transform target)
	{
		target.localScale = Vector3.zero;
		openCloseTween?.Kill();
		openCloseTween = target.DOScale(Vector3.one, duration)
			.SetEase(easeIn);
		await openCloseTween.AsyncWaitForCompletion();
	}
}