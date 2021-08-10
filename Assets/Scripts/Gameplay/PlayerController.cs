using UnityEngine;

namespace Gameplay
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float velocity = 2f;
        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
    
        private void FixedUpdate()
        {
            MovePlayer(Input.GetAxis("Horizontal"));
        }

        public void ResetPosition()
        {
            var position = transform.position;
            transform.position = new Vector3(0f, position.y, position.z);
        }
    
        private void MovePlayer(float xValue)
        {
            var direction = new Vector2(xValue, 0f);
            _rigidbody.velocity = direction * velocity;
        }
    }
}