using UnityEngine;
using Zenject;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Rigidbody2D))]
public class Ingredient3DView : MonoBehaviour
{
	[SerializeField]
	private RectTransform rectTransform;
	[SerializeField]
	private Rigidbody2D rigidBody;
	[SerializeField]
	private int shootForce;

	public void SetInitialPositionAndShootUp(Vector3 localInitialPosition)
	{
		rectTransform.localPosition = localInitialPosition;
		rigidBody.AddForce(Vector3.up * shootForce);
	}

	public class Factory : PlaceholderFactory<Object, Ingredient3DView>
	{
	}
}
