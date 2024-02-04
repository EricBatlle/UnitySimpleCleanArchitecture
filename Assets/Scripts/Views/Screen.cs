using System;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

public abstract class Screen : MonoBehaviour
{
    public abstract Type GetPresenterType();

    public class Factory : PlaceholderFactory<Object, Screen>
    {
    }
}