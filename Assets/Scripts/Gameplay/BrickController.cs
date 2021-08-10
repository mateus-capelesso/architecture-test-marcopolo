using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class BrickController : MonoBehaviour
    {
        public UnityEvent onBrickDestroied;
    
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.transform.CompareTag("Player")) return;
        
            onBrickDestroied.Invoke();
            Destroy(gameObject);
        }
    }
}