using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ScreensContainer", menuName = "ScriptableObjects/ScreensContainer", order = 1)]
public class ScreensContainer : ScriptableObject
{
    public List<GameObject> screenPrefabs;
    
    public GameObject GetScreenPrefab<TScreen>() where TScreen : Component
    {
        return screenPrefabs.FirstOrDefault(screen => screen && screen.GetComponent<TScreen>());
    }

    public List<Type> GetScreensPresenters()
    {
        var presenterComponents = new List<Type>();
        foreach (var screen in screenPrefabs) {
            var presenterType = screen.GetComponent<Screen>()?.GetPresenterType();
            presenterComponents.Add(presenterType);
        }
        return presenterComponents;
    }
}