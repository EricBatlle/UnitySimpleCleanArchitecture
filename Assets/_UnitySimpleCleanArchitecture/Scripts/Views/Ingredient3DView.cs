using UnityEngine;
using Zenject;

[RequireComponent(typeof(RectTransform))]
public class Ingredient3DView : MonoBehaviour
{
	[SerializeField]
	private RectTransform rectTransform;
	[SerializeField]
	private Rigidbody2D rigidBody;
	[SerializeField]
	private int initialShootForce;
	
	[SerializeField]
	private Ingredient ingredient;

	public Ingredient Ingredient => ingredient;

	[Inject]
	public void Inject(Ingredient ingredient)
	{
		this.ingredient = ingredient;
	}

	public void SetInitialPositionAndShootUp(Vector3 localInitialPosition)
	{
		rectTransform.localPosition = localInitialPosition;
		rigidBody.AddForce(Vector3.up * initialShootForce);
	}

	public class Factory : PlaceholderFactory<Object, Ingredient3DView>
	{
	}
}
