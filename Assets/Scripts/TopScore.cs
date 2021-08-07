using UnityEngine;
using UnityEngine.UI;

public class TopScore : MonoBehaviour
{
    public Text label;
    
    private void Awake()
    {
        label.text += GamePlay.Instance.GetScore().ToString();
    }
}