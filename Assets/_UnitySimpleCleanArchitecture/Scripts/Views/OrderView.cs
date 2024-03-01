using UnityEngine;
using Zenject;

public class OrderView : MonoBehaviour
{
	public class Factory : PlaceholderFactory<Object, OrderView>
	{
	}
}
