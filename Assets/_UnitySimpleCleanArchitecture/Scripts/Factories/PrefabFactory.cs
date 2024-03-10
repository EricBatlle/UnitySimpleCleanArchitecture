using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

public class PrefabFactory<T> : IFactory<Object, T>
{
	protected readonly DiContainer _container;

	public PrefabFactory(DiContainer container)
	{
		_container = container;
	}

	public T Create(Object prefab, Transform parentTransform)
	{
		return _container.InstantiatePrefabForComponent<T>(prefab, parentTransform);
	}

	public T Create(Object prefab)
	{
		return _container.InstantiatePrefabForComponent<T>(prefab);
	}
}