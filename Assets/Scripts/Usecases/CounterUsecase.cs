using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SCA
{
    // Usecase
    // Usecase can depend on Gateway through its interface.
    // Usecase can't be dependent on View, Presenter
    // Usecase can't inherit Monobehaviour
    public class CountUsecase
    {
        private readonly Dictionary<CountType, Count> _counts = new Dictionary<CountType, Count>();
        private readonly Dictionary<CountType, Count> _initialCounts = new Dictionary<CountType, Count>();

        // Dependency
        private readonly ICountDBGateway _gateway;
        private readonly SignalBus _signalBus;

        [Inject]
        public CountUsecase(ICountDBGateway gateway, SignalBus signalBus, Navigation navigation)
        {
            _gateway = gateway;
            _signalBus = signalBus;

            InitCount(CountType.A);
            InitCount(CountType.B);
            
            //navigation.Push<ScreenAView>();
        }

        private void InitCount(CountType type)
        {
            var count = new Count()
            {
                Type = type,
                Num = _gateway.GetCount(type)
            };
            _counts.Add(type, count);
            _initialCounts.Add(type, count);
        }

        public void IncrementCount(CountType type)
        {
            var current = _gateway.GetCount(type);
            var new_count = current + 1;
            _gateway.SetCount(type, new_count);

            // publish the value changed
            _counts[type].Num = new_count;
            _signalBus.Fire(new CountIncrementedSignal(_counts));
        }

        public Dictionary<CountType, Count> GetInitialCountValues()
        {
            return _initialCounts;
        }
    }
}