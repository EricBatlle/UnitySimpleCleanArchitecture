using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableIngredient : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	[SerializeField]
	private Rigidbody2D rb;
	[SerializeField]
	private bool isDragging = false;
	[SerializeField]
	private bool hoveringDropZone = false;
	[SerializeField]
	private float velocity = 0.001f;

	private Vector3 screenPoint;
	private Vector3 offset;

	private Vector3 lastMousePosition;
	private Vector3 initialPositionWhenStartDragging;

	public bool IsDragging => isDragging;

	public bool HoveringDropZone => hoveringDropZone;

	[Range(0.0f, 100.0f)]
	public float m_Damping = 1.0f;

	[Range(0.0f, 100.0f)]
	public float m_Frequency = 5.0f;

	public bool m_DrawDragLine = true;
	public Color m_Color = Color.cyan;

	private TargetJoint2D m_TargetJoint;

	public void OnPointerDown(PointerEventData eventData)
	{
		Debug.Log("DOWN");
		if (!isDragging)
		{
			//rb.Stop();

			// Add a target joint to the Rigidbody2D GameObject.
			m_TargetJoint = rb.gameObject.AddComponent<TargetJoint2D>();
			m_TargetJoint.dampingRatio = m_Damping;
			m_TargetJoint.frequency = m_Frequency;

			// Attach the anchor to the local-point where we clicked.
			m_TargetJoint.anchor = m_TargetJoint.transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z)));

			screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
			offset = gameObject.GetComponent<RectTransform>().position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
			isDragging = true;
			initialPositionWhenStartDragging = this.gameObject.GetComponent<RectTransform>().position;
			hoveringDropZone = true;
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (isDragging)
		{
			var worldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
			m_TargetJoint.target = worldPos;

			Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;
			//gameObject.GetComponent<RectTransform>().position = currentPosition;
			//rb.MovePosition(currentPosition);
			//gameObject.GetComponent<RectTransform>().position = currentPosition;
			lastMousePosition = Input.mousePosition;

			// Draw the line between the target and the joint anchor.
			if (m_DrawDragLine)
				Debug.DrawLine(m_TargetJoint.transform.TransformPoint(m_TargetJoint.anchor), worldPos, m_Color);
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (isDragging)
		{
			Debug.Log("UP");
			isDragging = false;
			//rb.WakeUp();
			//rb.isKinematic = false;

			Destroy(m_TargetJoint);
			m_TargetJoint = null;

			// Check if the dropped object is within the bounds of the target RectTransform
			//Vector2 mousePosition = Input.mousePosition;
			//Vector2 mouseVelocity = (Input.mousePosition - lastMousePosition) / Time.deltaTime;
			//rb.velocity = mouseVelocity * velocity;

			//this.gameObject.GetComponent<RectTransform>().position = initialPositionWhenStartDragging;
			//foreach (var rectTransform in droppableRectTransforms)
			//{
			//	if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePosition))
			//	{
			//		// Handle drop action here
			//		Debug.Log("Dropped inside target RectTransform!");
			//	}
			//}
		}
	}
}
