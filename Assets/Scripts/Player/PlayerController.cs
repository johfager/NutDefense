using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] int playerNumber = 0; // Player number to differentiate between players

        private PlayerMovement _playerMovement;

        void Start()
        {
            /*if (playerNumber == 0)
            {
                Debug.LogError("Player number not set in PlayerInput script, Can't be 0!");
            }*/
            _playerMovement = GetComponent<PlayerMovement>();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            Debug.Log("Inside OnJump");
            if (context.performed)
            {
                Debug.Log($"{gameObject.name} jumped!");
                // Add your jump logic here
                _playerMovement.Jump();
            }
        }
    }
}
