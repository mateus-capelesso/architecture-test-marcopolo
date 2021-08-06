using UnityEngine;
using UnityEngine.Events;
public class Death : MonoBehaviour
{
    public UnityEvent onPlayerDeath;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            onPlayerDeath.Invoke();
        }
        
        //TODO: Remove these lines
        // GamePlay.Instance.Lives--;
        // GamePlay.Instance.Goal();
    }
}