using Player;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform player1SpawnPoint;
    public Transform player2SpawnPoint;

    
    
    //Local Multiplayer same input device script
    void Start()
    {
        // Instantiate Player 1 with "Keyboard1" control scheme
        PlayerInput p1 = PlayerInput.Instantiate(
            playerPrefab,
            controlScheme: "Keyboard1");
        InputUser.PerformPairingWithDevice(Keyboard.current, p1.user);
        p1.user.ActivateControlScheme("Keyboard1");
        p1.name = "Player1";
        
        // Instantiate Player 2 with "Keyboard2" control scheme
        PlayerInput p2 = PlayerInput.Instantiate(
            playerPrefab,
            controlScheme: "Keyboard2");
        p2.user.ActivateControlScheme("Keyboard2");
        InputUser.PerformPairingWithDevice(Keyboard.current, p2.user);
        p2.name = "Player2";
        
        
        // Set starting positions
        p1.transform.position = player1SpawnPoint.position;
        p2.transform.position = player2SpawnPoint.position;
    }

}
