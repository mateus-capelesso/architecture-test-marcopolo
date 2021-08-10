using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TopScore : MonoBehaviour
    {
        private Text _label;
    
        private void Start()
        {
            GameManager.Instance.onLevelOver += SetText;
        }

        private void SetText(int points)
        {
            _label.text += points.ToString();
        }
    }
}