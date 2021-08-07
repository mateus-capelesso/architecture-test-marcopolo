﻿using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _rigidbody.velocity.normalized * speed;
    }

    public void ResetBall()
    {
        transform.position = Vector3.zero;
        _rigidbody.velocity = Vector2.zero;
    }


// Force kick to go to the bottom of the screen
    public void Kick()
    {
        var direction = Random.insideUnitCircle;
        _rigidbody.velocity =  new Vector2(direction.x, Mathf.Clamp(direction.y, -1f, 0.1f)) * speed;
    }


}