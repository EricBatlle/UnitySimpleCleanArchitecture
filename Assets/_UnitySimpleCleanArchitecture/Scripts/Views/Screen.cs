using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

[RequireComponent(typeof(RectTransform))]
public abstract class Screen : MonoBehaviour
{
	[SerializeField]
	private RectTransform rectTransform;
	[SerializeField]
	protected bool isHided;
	[SerializeField]
	protected ScreenTransition openScreenTransition;
	[SerializeField]
	protected ScreenTransition closeScreenTransition;

	public abstract Type GetPresenterType();

	public Action OpenAnimationComplete;
	public Action HideAnimationComplete;

	protected virtual void OnOpenAnimationComplete()
	{
		isHided = false;
		OpenAnimationComplete?.Invoke();
	}

	protected virtual void OnHideAnimationComplete()
	{
		isHided = true;
		HideAnimationComplete?.Invoke();
	}

	public virtual async Task Show()
	{
		if (openScreenTransition == null)
		{
			OnOpenAnimationComplete();
			return;
		}
		await openScreenTransition.Animate(transform);
		OnOpenAnimationComplete();
	}

	public virtual async Task Hide()
	{
		if (isHided || closeScreenTransition == null)
		{
			OnHideAnimationComplete();
			return;
		}
		await closeScreenTransition.Animate(transform);
		OnHideAnimationComplete();
	}

	public void StretchCompletly()
	{
		this.rectTransform.anchorMin = Vector2.zero;
		this.rectTransform.anchorMax = new Vector2(1, 1);
		this.rectTransform.anchoredPosition = Vector2.zero;
		this.rectTransform.sizeDelta = Vector2.zero;
		this.rectTransform.pivot = new Vector2(0.5f, 0.5f);
	}

	public class Factory : PlaceholderFactory<Object, Screen>
	{
	}
}