using UnityEngine;

public abstract class ScreenWithIntent<TScreenIntent> : Screen where TScreenIntent : ScreenIntent
{
    [SerializeField]
    private TScreenIntent intent;
    
    protected TScreenIntent Intent {
        get {
            if (intent == null) {
                Debug.LogError($"Trying to access Intent of type {typeof(TScreenIntent)} in Screen {name} when still not assigned.");
            }
            return intent;
        }
        private set => intent = value;
    }

    protected abstract void OnIntentSetCompleted();

    public void SetIntentAndShow(TScreenIntent screenIntent)
    {
        Intent = screenIntent;
        OnIntentSetCompleted();
        Show();
    }
}