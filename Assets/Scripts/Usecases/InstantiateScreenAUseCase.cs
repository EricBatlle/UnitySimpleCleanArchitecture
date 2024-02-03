using UnityEngine;
using Zenject;

public class InstantiateScreenAUseCase
{
    private SignalBus signalBus;
    private Navigation navigation;
    
    [Inject]
    public InstantiateScreenAUseCase(SignalBus signalBus, Navigation navigation)
    {
        this.signalBus = signalBus;
        this.navigation = navigation;
        signalBus.Subscribe<CountIncrementedSignal>(OnCountIncremented);
    }
    
    private void OnCountIncremented(CountIncrementedSignal signal)
    {
        if (signal.GetTotalCount() > 3) {
            navigation.Create<ScreenAView>();
        }
    }
}
