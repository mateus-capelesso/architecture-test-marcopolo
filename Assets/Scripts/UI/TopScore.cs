using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TopScore : MonoBehaviour
    {
        public Text _label;

        private void Start()
        {
            GameManager.Instance.onTotalPointsAvailable += SetText;
        }

        private void SetText(int points)
        {
            _label.text += points.ToString();
        }
    }
}