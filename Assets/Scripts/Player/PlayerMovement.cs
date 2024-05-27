using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] public float speed = 10f;
        [SerializeField] public float jumpForce = 5f;

        private Rigidbody2D _rb;
        private bool _grounded;

        // Unity event to be invoked when the player changes direction
        public UnityEvent<GameObject, Vector3> onDirectionChange = new UnityEvent<GameObject, Vector3>();

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
                // Change direction
                speed = -speed;
                
                // Invoke the Unity event with the player GameObject as an argument
                if(speed > 0)
                {
                    onDirectionChange.Invoke(gameObject, Vector3.right);
                }
                else
                {
                    onDirectionChange.Invoke(gameObject, Vector3.left);
                }
 
            }

            if (collision.gameObject.CompareTag("Floor"))
            {
                _grounded = true;
            }
        }
    }
}