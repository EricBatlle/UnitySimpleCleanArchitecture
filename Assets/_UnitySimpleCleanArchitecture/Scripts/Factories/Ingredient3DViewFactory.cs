using UnityEngine;
using Zenject;

public class Ingredient3DViewFactory : PrefabFactory<Ingredient3DView>
{
	public Ingredient3DViewFactory(DiContainer container) : base(container)
	{
	}

	public Ingredient3DView Create(Object prefab, Transform parentTransform, Ingredient ingredient)
	{
		return _container.InstantiatePrefabForComponent<Ingredient3DView>(prefab, parentTransform, new object[] { ingredient });
	}
}
