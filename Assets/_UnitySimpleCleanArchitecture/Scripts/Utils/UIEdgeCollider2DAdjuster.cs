using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(EdgeCollider2D))]
public class UIEdgeCollider2DAdjuster : MonoBehaviour
{
	[SerializeField]
	private EdgeCollider2D edgeCollider2D;
	[SerializeField]
	private RectTransform rectTransform;

	private void Awake()
	{
		UpdateColliderSize();
	}

#if UNITY_EDITOR
	private void Update()
	{
		UpdateColliderSize();
	}
#endif

	private void UpdateColliderSize()
	{
		edgeCollider2D.offset = new Vector2(-(rectTransform.rect.width/2), -(rectTransform.rect.height/2));
		var points = new Vector2[5];
		points[0] = Vector2.zero;
		points[1] = new Vector2(rectTransform.rect.width, 0);
		points[2] = new Vector2(rectTransform.rect.width, rectTransform.rect.height);
		points[3] = new Vector2(0, rectTransform.rect.height);
		points[4] = Vector2.zero;
		edgeCollider2D.points = points;
	}
}
