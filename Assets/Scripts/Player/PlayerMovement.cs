using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] public float speed = 10f;
        [SerializeField] public float jumpForce = 5f;

        private Rigidbody2D _rb;
        private bool _grounded;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            // Automatic horizontal movement
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        public void Jump()
        {
            if (_grounded)
            {
                _grounded = false;
                _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Edge"))
            {
                speed = -speed;
            }

            if (collision.gameObject.CompareTag("Floor"))
            {
                _grounded = true;
            }
        }
    }
}