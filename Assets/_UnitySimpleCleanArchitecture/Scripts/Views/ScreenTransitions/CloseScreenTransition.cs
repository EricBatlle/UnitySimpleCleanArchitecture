using DG.Tweening;
using System;
using System.Threading.Tasks;
using UnityEngine;

public class CloseScreenTransition : ScreenTransition
{
	[SerializeField]
	protected float duration = 0.35f;
	[SerializeField]
	protected Ease easeOut = Ease.InBack;

	private Tween openCloseTween;

	public override async Task Animate(Transform target)
	{
		openCloseTween?.Kill();
		openCloseTween = transform.DOScale(Vector3.zero, duration)
			.SetEase(easeOut);
		await openCloseTween.AsyncWaitForCompletion();
	}
}