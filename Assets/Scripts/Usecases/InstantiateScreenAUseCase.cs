using UnityEngine;
using Zenject;

public class InstantiateScreenAUseCase
{
    private SignalBus signalBus;
    
    public void Initialize(SignalBus signalBus)
    {
        this.signalBus = signalBus;
        signalBus.Subscribe<CountIncrementedSignal>(OnCountIncremented);
    }
    
    public void SayHello()
    {
        Debug.Log($"Hello from {this}");
    }
    
    private void OnCountIncremented(CountIncrementedSignal signal)
    {
        if (signal.GetTotalCount() > 3) {
        }
    }
}
