using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float velocity;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Detect inputs, if not is being pressed, sends 0 as direction to stay on position
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MovePlayer(Vector2.left);
            return;
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MovePlayer(Vector2.right);
            return;
        }
        
        MovePlayer(Vector2.zero);
        
    }

    
    private void MovePlayer(Vector2 direction)
    {
        _rigidbody.velocity = direction * velocity;
    }
}