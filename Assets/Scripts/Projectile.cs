using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _launchDirection;
    private float _launchForce;
    private GameObject _owner; // The player who shot this projectile

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(Vector2 launchDirection, float launchForce, GameObject owner)
    {
        _launchDirection = launchDirection;
        _launchForce = launchForce;
        _owner = owner;

        // Apply the launch force to the projectile
        _rb.AddForce(_launchDirection * _launchForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the projectile hit another player
        if (collision.gameObject.CompareTag("Player") && collision.gameObject != _owner)
        {
            // Handle the logic for killing the player
            Debug.Log($"{collision.gameObject.name} hit by projectile!");
            //Destroy(collision.gameObject); // Example: destroy the player game object

            // Destroy the projectile after hitting the player
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Edge"))
        {
            // Reflect the velocity to simulate a bounce
            Vector2 normal = collision.contacts[0].normal;
            _rb.velocity = Vector2.Reflect(_rb.velocity, normal) * 0.8f; // Reduce the speed after bouncing
            Debug.Log("TODO should bounce of the wall here");
        }
        else if (collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("TODO should get stuck in floor here jao");
            Destroy(this.gameObject);
        }
    }
}