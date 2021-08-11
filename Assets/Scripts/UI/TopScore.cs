using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TopScore : MonoBehaviour
    {
        public Text label;

        private void Start()
        {
            GameManager.Instance.onTotalPointsAvailable += SetText;
        }

        private void SetText(int points)
        {
            label.text += points.ToString();
        }
    }
}