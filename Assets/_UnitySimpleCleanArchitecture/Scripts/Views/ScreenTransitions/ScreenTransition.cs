using System;
using System.Threading.Tasks;
using UnityEngine;

public abstract class ScreenTransition : MonoBehaviour
{
	public abstract Task Animate(Transform target);
}