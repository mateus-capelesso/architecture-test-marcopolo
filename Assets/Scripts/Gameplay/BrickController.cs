using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class BrickController : MonoBehaviour
    {
        public UnityEvent onBrickDestroyed;
    
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.transform.CompareTag("Ball")) return;
        
            onBrickDestroyed.Invoke();
            Destroy(gameObject);
        }
    }
}