using System;
using UnityEngine;

namespace Gameplay
{
    public class PlayerController : MonoBehaviour
    {
        private enum InputConstraints {Left, Right, None}
        [SerializeField] private float velocity = 2f;
        private Rigidbody2D _rigidbody;
        [SerializeField] private InputConstraints _constraints = InputConstraints.None;

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
            xValue = CheckConstraints(xValue);
            var direction = new Vector2(xValue, 0f);
            _rigidbody.velocity = direction * velocity;
        }

        private float CheckConstraints(float value)
        {
            if (_constraints == InputConstraints.Left)
            {
                if (value < 0f)
                {
                    value = 0f;
                }
                else
                {
                    _constraints = InputConstraints.None;
                }
            }
            
            if (_constraints == InputConstraints.Right)
            {
                if (value > 0f)
                {
                    value = 0f;
                }
                else
                {
                    _constraints = InputConstraints.None;
                }
            }

            return value;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.transform.CompareTag("Wall")) return;

            _constraints = transform.position.x > 0f ? InputConstraints.Right : InputConstraints.Left;
        }
    }
}