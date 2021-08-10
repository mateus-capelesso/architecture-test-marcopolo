using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class Death : MonoBehaviour
    {
        public UnityEvent onDeathZone;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Ball"))
            {
                onDeathZone.Invoke();
            }
        }
    }
}