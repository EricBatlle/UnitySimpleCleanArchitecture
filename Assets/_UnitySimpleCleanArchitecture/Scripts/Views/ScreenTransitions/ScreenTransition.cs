using System;
using UnityEngine;

public abstract class ScreenTransition : MonoBehaviour
{
	public abstract void Animate(Transform target, Action onComplete = null);
}