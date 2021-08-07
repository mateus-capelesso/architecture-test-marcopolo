using UnityEngine;
using UnityEngine.UI;

public class TopScore : MonoBehaviour
{
    private Text _label;
    
    private void Awake()
    {
        GetComponent<Text>().text += GamePlay.Instance.GetScore().ToString();
    }
}