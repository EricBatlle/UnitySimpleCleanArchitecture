using UnityEngine;
using Zenject;

public class ScreenAPresenter
{
    private SignalBus signalBus;
    private Navigation navigation;
    
    [Inject]
    public void Initialize(SignalBus signalBus, Navigation navigation)
    {
        this.signalBus = signalBus;
        this.navigation = navigation;
        signalBus.Subscribe<CountIncrementedSignal>(OnCountIncremented);
        SayHello();
    }
    
    public void SayHello()
    {
        Debug.Log($"Hello from {this}");
    }

    public void CloseScreen(Screen screen)
    {
        navigation.Remove(screen);
    }
    
    private void OnCountIncremented(CountIncrementedSignal signal)
    {
       // UpdateCountView(signal.counts);
    }
}
