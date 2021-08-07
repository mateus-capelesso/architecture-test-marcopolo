using UnityEngine;

public class BrickController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.transform.CompareTag("Player")) return;
        
        GamePlay.Instance.BrickDestroyed();
        Destroy(gameObject);
    }
}