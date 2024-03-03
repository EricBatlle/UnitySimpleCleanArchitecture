using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(BoxCollider2D))]
public class UIBoxCollider2DAdjuster : MonoBehaviour
{
	[SerializeField]
	private BoxCollider2D boxCollider2D;
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
		boxCollider2D.size = new Vector2(rectTransform.rect.width, rectTransform.rect.height);
	}
}
