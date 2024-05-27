using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private float launchDirection;
    private float launchForce;
    private float launchAngle;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(float direction, float force, float angle)
    {
        launchDirection = direction;
        launchForce = force;
        launchAngle = angle;

        Launch();
    }

    void Launch()
    {
        // Calculate the launch angle in radians
        float angleInRadians = launchAngle * Mathf.Deg2Rad;

        // Adjust the launch direction based on the angle
        Vector2 launchVector = new Vector2(
            launchDirection * Mathf.Cos(angleInRadians),
            Mathf.Sin(angleInRadians)
        );

        // Apply the force to the projectile
        rb.AddForce(launchVector * launchForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Handle collision logic here
        //Destroy(gameObject);
    }
}