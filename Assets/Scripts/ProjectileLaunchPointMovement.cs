using UnityEngine;

public class ProjectileLaunchPointMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float rotationSpeed = 2f;
    private bool rotateClockwise = true; // Flag to control rotation direction
    
    private Transform launchPointTransform;

    void Start()
    {
        launchPointTransform = transform;
    }
/*
    void OnEnable()
    {
        // Subscribe to the onDirectionChange event of the associated PlayerMovement component
        player.GetComponent<Player.PlayerMovement>().onDirectionChange.AddListener(MoveToFront);
    }

    void OnDisable()
    {
        // Unsubscribe from the onDirectionChange event
        player.GetComponent<Player.PlayerMovement>().onDirectionChange.RemoveListener(MoveToFront);
    }
*/
    void MoveToFront(GameObject playerObject, Vector3 direction)
    {
        if (playerObject == player)
        {
            // Ensure that the launch point is in front of the player
            Vector3 offset = direction; // Adjust this value to position the launch point relative to the player
            launchPointTransform.position = player.transform.position + offset;
        }
    }
    

    void Update()
    {
        // Calculate the rotation angle based on the rotation direction
        float rotationAngle = rotateClockwise ? 90f : -90f;

        //transform.position = transform.parent.forward;
        // Rotate the launch point around the player
        transform.RotateAround(transform.parent.position, Vector3.forward, rotationAngle * Time.deltaTime * rotationSpeed);

        // Check if the rotation angle exceeds 90 degrees or -90 degrees
        if (Mathf.Abs(transform.localEulerAngles.z) >= 90f)
        {
            // Reverse the rotation direction
            rotateClockwise = !rotateClockwise;
        }
    }
}

/*using TreeEditor;
using UnityEngine;

public class ProjectileLaunchPointMovement : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 2f;
    private bool rotateClockwise = true; // Flag to control rotation direction

    void Update()
    {
        // Calculate the rotation angle based on the rotation direction
        float rotationAngle = rotateClockwise ? 90f : -90f;

        //transform.position = transform.parent.forward;
        // Rotate the launch point around the player
        transform.RotateAround(transform.parent.position, Vector3.forward, rotationAngle * Time.deltaTime * rotationSpeed);

        // Check if the rotation angle exceeds 90 degrees or -90 degrees
        if (Mathf.Abs(transform.localEulerAngles.z) >= 90f)
        {
            // Reverse the rotation direction
            rotateClockwise = !rotateClockwise;
        }
    }
}*/