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
}