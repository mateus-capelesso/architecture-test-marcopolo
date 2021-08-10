using UnityEngine;

namespace UI
{
    public class CanvasController : MonoBehaviour
    {
        # region Singleton

        private static CanvasController _instance;

        public static CanvasController Instance
        {
            get
            {
                if (_instance == null)
                {
                    var go = new GameObject("Canvas");
                    _instance = go.AddComponent<CanvasController>();
                }

                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance != null) return;

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        #endregion
    
        public GameObject mainCanvas;
        public GameObject gameplayCanvas;
        public GameObject winCanvas;
        public GameObject loseCanvas;

        public void ActivateMainMenu()
        {
            DeactivateCanvas();
            mainCanvas.SetActive(true);
        }
    
        public void ActivateGameplayCanvas()
        {
            DeactivateCanvas();
            gameplayCanvas.SetActive(true);
        }
    
        public void ActivateWinCanvas()
        {
            DeactivateCanvas();
            winCanvas.SetActive(true);
        }
    
        public void ActivateLoseCanvas()
        {
            DeactivateCanvas();
            loseCanvas.SetActive(true);
        }
    
        private void DeactivateCanvas()
        {
            mainCanvas.SetActive(false); 
            gameplayCanvas.SetActive(false); 
            winCanvas.SetActive(false);
            loseCanvas.SetActive(false); 
        }
    
    }
}