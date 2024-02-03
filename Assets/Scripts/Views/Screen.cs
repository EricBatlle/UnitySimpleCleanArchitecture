using System;
using UnityEngine;
using Zenject;

public abstract class Screen : MonoBehaviour
{
    public abstract Type GetPresenterType();

    public class Factory : PlaceholderFactory<UnityEngine.Object, Screen>
    {
    }
}