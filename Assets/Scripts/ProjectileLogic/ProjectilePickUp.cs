using Player;
using UnityEngine;

public class ProjectilePickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null && !playerController.HasProjectile())
            {
                // Give the player a projectile
                playerController.PickupProjectile();

                // Destroy the pickup
                Destroy(gameObject);
            }
        }
    }
}