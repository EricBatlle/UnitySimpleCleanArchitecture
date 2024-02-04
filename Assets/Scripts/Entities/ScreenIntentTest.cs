using System;
using UnityEngine;

[Serializable]
public class ScreenIntentTest : ScreenIntent
{
    [SerializeField]
    private string text = "Test";

    public string Text => text;
}