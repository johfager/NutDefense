using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] PlayerMovement playerMovement;
        [SerializeField] GameObject projectilePrefab;
        [SerializeField] Transform launchPoint;
        [SerializeField] float launchForce = 1f;
        [SerializeField] float launchAngle = 45f;

        private bool hasProjectile = true;

        public void OnJump(InputAction.CallbackContext context)
        {
            Debug.Log("Inside OnJump");
            if (context.performed)
            {
                if (hasProjectile)
                {
                    Debug.Log($"{gameObject.name} shot a projectile!");
                    LaunchProjectile();
                    hasProjectile = false;
                    //Disable launch point UI until projectile is picked up again
                    launchPoint.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                }
                else
                {
                    Debug.Log($"{gameObject.name} jumped!");
                    playerMovement.Jump();
                }
            }
        }

        void LaunchProjectile()
        {
            // Instantiate the projectile at the launch point
            GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, launchPoint.rotation);

            // Determine the launch direction based on the current rotation of the launch point
            Vector2 launchDirection = launchPoint.up; // Assuming the launch point's up direction is the launch direction

            // Get the Projectile script component from the instantiated projectile
            Projectile projectileScript = projectile.GetComponent<Projectile>();

            // Initialize the projectile with the direction, force, and owner
            projectileScript.Initialize(launchDirection, launchForce, gameObject);
        }
    }
}