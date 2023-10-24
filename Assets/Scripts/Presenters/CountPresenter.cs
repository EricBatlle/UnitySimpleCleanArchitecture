using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;

namespace SCA
{
    // Presenter
    // Presenter can depend on Usecase through its interface
    // Presenter can't dependent on View, Gateway
    // Presenter can inherit Monobehaviour
    public class CountPresenter : MonoBehaviour
    {
        [SerializeField]
        private TotalNumberTextView totalNumberTextView;
        [SerializeField]
        private List<CountTextView> countTextViews;

        // Dependency
        private CountUsecase _usecase;
        private SignalBus _signalBus;

        [Inject]
        public void Initialize(CountUsecase usecase, SignalBus signalBus)
        {
            _usecase = usecase;
            _signalBus = signalBus;
            
            _signalBus.Subscribe<CountIncrementedSignal>(OnCountIncremented);

            // ... and update initialize by the current value
            UpdateCountView(_usecase.GetInitialCountValues());
        }
        
        public void IncrementCount(CountType type)
        {
            _usecase.IncrementCount(type);
        }

        private void OnCountIncremented(CountIncrementedSignal signal)
        {
            UpdateCountView(signal.counts);
        }

        private void UpdateCountView(Dictionary<CountType, Count> dict)
        {
            foreach (var textView in countTextViews) {
                textView.UpdateText(dict[textView.Type].Num);
            }

            totalNumberTextView.UpdateCount(dict[CountType.A].Num, dict[CountType.B].Num);
        }
    }
}