using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] PlayerMovement playerMovement;
        /*public string controlSchemeName;

        private void OnEnable()
        {
            StartCoroutine(SwitchControlSchemeNextFrame());
        }

        private IEnumerator SwitchControlSchemeNextFrame()
        {
            yield return null; // Wait until the next frame
            var playerInput = GetComponent<PlayerInput>();
            if (!string.IsNullOrEmpty(controlSchemeName))
            {
                Debug.Log($"Assigning control scheme {controlSchemeName} to {gameObject.name}");
                playerInput.SwitchCurrentControlScheme(controlSchemeName, Keyboard.current);
            }
            else
            {
                Debug.LogError($"Control scheme for {gameObject.name} is null or empty!");
            }
            playerInput.onActionTriggered += OnActionTriggered;
        }

        private void OnDisable()
        {
            var playerInput = GetComponent<PlayerInput>();
            playerInput.onActionTriggered -= OnActionTriggered;
        }

        private void OnActionTriggered(InputAction.CallbackContext context)
        {
            if (context.performed && context.action.name == "Jump")
            {
                Debug.Log($"{gameObject.name} jumped!");
                _playerMovement.Jump();
                // Add your jump logic here
            }
        }*/
        
        /*void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }*/

        public void OnJump(InputAction.CallbackContext context)
        {
            Debug.Log("Inside OnJump");
            if (context.performed)
            {
                Debug.Log($"{gameObject.name} jumped!");
                // Add your jump logic here
                playerMovement.Jump();
            }
        }
    }
}
