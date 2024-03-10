using UnityEngine;

#if UNITY_EDITOR
public class ClickDetectorGizmo : MonoBehaviour
{
	[SerializeField]
	private float radius = 0.5f;
	[SerializeField]
	private Color color = Color.red;

	private Vector3 gizmoPosition;

	private void Awake()
	{
		Debug.LogWarning($"You have a {typeof(ClickDetectorGizmo)} attached to the scene, remember to remove it when you end the debugging session");
	}

	private void Update()
	{
		// Verifica si se hizo clic en la pantalla
		if (Input.GetMouseButtonDown(0))
		{
			// Obtén la posición del clic en la pantalla
			Vector3 mousePosition = Input.mousePosition;

			// Convierte la posición del clic en la pantalla a una posición en el mundo
			gizmoPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));

			// Forzar un repintado de la vista de la escena
			UnityEditor.SceneView.RepaintAll();
		}
	}

	private void OnDrawGizmos()
	{
		// Dibuja el gizmo en la posición obtenida
		Gizmos.color = color;
		gizmoPosition.z = 100;
		Gizmos.DrawWireSphere(gizmoPosition, radius);
	}
}
#endif