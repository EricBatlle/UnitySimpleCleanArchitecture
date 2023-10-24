using UnityEngine;
using UnityEngine.UI;

namespace SCA
{
    // View
    // View can depend on the Presenter through its interface
    // View can't depend on another View.
    // View can't depend on Use Case, Gateway
    // View can inherit Monobehaviour
    public class CountTextView : MonoBehaviour
    {
        public CountType Type;
        
        [SerializeField] 
        private Text _text;

        private void Start()
        {
            UpdateText(0); // Initialize
        }

        public void UpdateText(int count)
        {
            _text.text = string.Format("Count {0} = {1}", Type.ToString(), count);
        }
    }
}