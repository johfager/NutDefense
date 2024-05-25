using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed = 10f;
    [SerializeField] float _jumpForce = 5f;
    
    private Rigidbody2D _rb;
    private bool _grounded;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Automatic horizontal movement
        transform.position += new Vector3(_speed * Time.deltaTime, 0, 0);
        
        // Jumping
        if (Input.GetButtonDown("Jump") && _grounded)
        {
            _grounded = false;
            _rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player has collided with an edge
        if (collision.gameObject.CompareTag("Edge"))
        {
            // Reverse the direction of the player's speed
            _speed = -_speed;
        }

        // Check if the player has collided with the floor, reset the grounded variable
        if (collision.gameObject.CompareTag("Floor"))
        {
            // Reverse the direction of the player's speed
            _grounded = true;
        }
    }
}