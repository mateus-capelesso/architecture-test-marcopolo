using UnityEngine;
using UnityEngine.UI;

public class TopPanelController : MonoBehaviour
{
    public Text score;
    public Text lives;

    private void Start()
    {
        GamePlay.Instance.onLivesUpdate.AddListener(UpdateLivesText);
        GamePlay.Instance.onScoreUpdate.AddListener(UpdateScoreText);
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
