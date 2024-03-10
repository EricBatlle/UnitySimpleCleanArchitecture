using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableIngredient : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[SerializeField]
	private Rigidbody2D ingredientModelRigidbody;
	[SerializeField]
	private Ingredient3DView ingredient3DView;
	[Space()]
	[Range(0.0f, 100.0f)]
	[SerializeField]
	private float m_Damping = 15.0f;
	[Range(0.0f, 100.0f)]
	[SerializeField]
	private float m_Frequency = 2.0f;
	[SerializeField]
	private bool m_DrawDragLine = true;
	[SerializeField]
	private Color m_Color = Color.cyan;
	[Space()]
	[SerializeField]
	private bool isDragging = false;
	[SerializeField]
	private bool isHoveringDropZone = false;

	private TargetJoint2D m_TargetJoint;
	private Vector3 initialPositionWhenStartDragging;
	private IngredientDropZone ingredientDropZone;
	private Ingredient Ingredient => ingredient3DView.Ingredient;

	public void OnPointerDown(PointerEventData eventData)
	{
		if (!isDragging)
		{
			isDragging = true;

			transform.SetLayerRecursively(Layers.DRAGGABLE_INGREDIENT);

			// Add a target joint to the Rigidbody2D GameObject.
			m_TargetJoint = ingredientModelRigidbody.gameObject.AddComponent<TargetJoint2D>();
			m_TargetJoint.dampingRatio = m_Damping;
			m_TargetJoint.frequency = m_Frequency;

			// Attach the anchor to the local-point where we clicked.
			var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			m_TargetJoint.anchor = m_TargetJoint.transform.InverseTransformPoint(worldPos);

			initialPositionWhenStartDragging = gameObject.GetComponent<RectTransform>().position;
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (isDragging)
		{
			isDragging = false;

			transform.SetLayerRecursively(Layers.UI);

			Destroy(m_TargetJoint);
			m_TargetJoint = null;

			if (!isHoveringDropZone)
			{
				ingredientModelRigidbody.velocity = Vector3.zero;
				gameObject.GetComponent<RectTransform>().position = initialPositionWhenStartDragging;
			}
			else if (Ingredient != null)
			{
				ingredientDropZone.SetDroppedIngredient(Ingredient);
			}
		}
	}

	private void Update()
	{
		if (isDragging)
		{
			var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			m_TargetJoint.target = worldPos;

#if UNITY_EDITOR
			// Draw the line between the target and the joint anchor.
			if (m_DrawDragLine)
				Debug.DrawLine(m_TargetJoint.transform.TransformPoint(m_TargetJoint.anchor), worldPos, m_Color);
#endif
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		var ingredientDropZone = collision.gameObject.GetComponent<IngredientDropZone>();
		if (ingredientDropZone)
		{
			this.ingredientDropZone = ingredientDropZone;
			isHoveringDropZone = true;
		}
		else
		{
			isHoveringDropZone = false;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<IngredientDropZone>())
		{
			isHoveringDropZone = false;
		}
	}


}
