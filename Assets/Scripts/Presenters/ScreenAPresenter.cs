using UnityEngine;
using Zenject;

public class ScreenAPresenter
{
    private SignalBus signalBus;
    
    [Inject]
    public void Initialize(SignalBus signalBus)
    {
        this.signalBus = signalBus;
        signalBus.Subscribe<CountIncrementedSignal>(OnCountIncremented);
        SayHello();
    }
    
    public void SayHello()
    {
        Debug.Log($"Hello from {this}");
    }
    
    private void OnCountIncremented(CountIncrementedSignal signal)
    {
       // UpdateCountView(signal.counts);
    }
}
