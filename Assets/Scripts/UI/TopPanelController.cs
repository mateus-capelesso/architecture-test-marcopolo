using Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TopPanelController : MonoBehaviour
    {
        public GamePlay gameplay;
        [SerializeField] private Text score;
        [SerializeField] private Text lives;

        public void ActivateTopPanel()
        {
            gameObject.SetActive(true);
            gameplay.onLivesUpdate += UpdateLivesText;
            gameplay.onScoreUpdate += UpdateScoreText;
        }

        private void UpdateLivesText(int value)
        {
            lives.text = "Lives: " + value;
        }
    
        private void UpdateScoreText(int value)
        {
            score.text = "Score: " + value;
        }
    }
}
