using UnityEngine;
using UnityEngine.UI;

namespace SCA
{
    // View
    // View can depend on the Presenter through its interface
    // View can't depend on another View.
    // View can't depend on Use Case, Gateway
    // View can inherit Monobehaviour
    public class TotalNumberTextView : MonoBehaviour
    {
        [SerializeField]
        private Text _text;

        public void UpdateCount(int a, int b)
        {
            var total = a + b;
            _text.text = string.Format("Total = {0}", total);
        }
    }
}